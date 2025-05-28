using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    class EtatSol : EtatAeronef
    {
        public override void AvancerPas(double pas)
        {
            Console.WriteLine($"[Sol] Aéronef stationné pendant {pas} pas.");
        }

        public override TypeEtat GetTypeEtat()
        {
            return TypeEtat.Sol;
        }

        public override void Avancer(double dureeMinutes, Aeronef aeronef , Scenario scenario)
        {
            // Aucun changement d'état, il attend une affectation
        }

        public void VerifierEtDeclencherEmbarquement(List<Aeroport> aeroports)
        {
            foreach (var aeroport in aeroports)
            {
                Console.WriteLine("Début vérification aéroport");

                foreach (var aeronef in aeroport.Aeronefs)
                {
                    if (aeronef.EtatActuel.GetTypeEtat() != TypeEtat.Sol)
                        continue;

                    Console.WriteLine($"Vérification de l'aéronef {aeronef.Nom} au sol.");

                    if (aeronef is AvionPassager avionPassager)
                    {
                        var groupes = aeroport.Clients
                            .OfType<Passager>()
                            .GroupBy(p => p.Destination)
                            .Select(g => new
                            {
                                Destination = g.Key,
                                Nombre = g.Count(),
                                Clients = g.ToList()
                            });

                        foreach (var grp in groupes)
                        {
                            if (grp.Nombre >= 0.8 * avionPassager.Capacite)
                            {
                                var aEmbarquer = grp.Clients.Take(avionPassager.Capacite).ToList();
                                aeroport.Clients.RemoveAll(c => aEmbarquer.Contains(c));

                                var destinationAeroport  = grp.Destination;
                                if (destinationAeroport == null)
                                {
                                    Console.WriteLine($"[Erreur] Destination {grp.Destination.Nom} introuvable !");
                                    continue;
                                }

                                // Mise à jour des positions
                                avionPassager.PositionActuelle = aeroport.Position;
                                avionPassager.Destination = destinationAeroport;
                                

                                // Calcul du temps d'embarquement
                                double tempsTotal = aEmbarquer.Count * avionPassager.TempsEmbarquement;

                                Console.WriteLine($"Passagers prêts à embarquer pour {grp.Destination.Nom}. Temps total : {tempsTotal} minutes.");

                                // Changement d'état
                                aeronef.CreerEtatDepuisType(TypeEtat.Embarquement, tempsEmbarquementTotal: tempsTotal);
                                break;
                            }
                        }
                    }
                    else if (aeronef is AvionCargaison avionCargo)
                    {
                        var groupes = aeroport.Clients
                            .OfType<Cargo>()
                            .GroupBy(c => c.Destination)
                            .Select(g => new
                            {
                                Destination = g.Key,
                                TotalPoids = g.Sum(c => c.PoidsCargaison),
                                Clients = g.ToList()
                            });

                        foreach (var grp in groupes)
                        {
                            if (grp.TotalPoids >= 0.8 * avionCargo.Capacite)
                            {
                                double poidsCumule = 0;
                                var aEmbarquer = new List<Cargo>();

                                foreach (var client in grp.Clients)
                                {
                                    if (poidsCumule + client.PoidsCargaison <= avionCargo.Capacite)
                                    {
                                        poidsCumule += client.PoidsCargaison;
                                        aEmbarquer.Add(client);
                                    }
                                }

                                aeroport.Clients.RemoveAll(c => aEmbarquer.Contains(c));

                                var destinationAeroport =  grp.Destination;
                                if (destinationAeroport == null)
                                {
                                    Console.WriteLine($"[Erreur] Destination {grp.Destination.Nom} introuvable !");
                                    continue;
                                }

                                // Mise à jour des positions
                                avionCargo.PositionActuelle = aeroport.Position;
                                avionCargo.Destination = destinationAeroport;
                                

                                // Calcul du temps d’embarquement
                                double tempsTotal = aEmbarquer.Sum(c => c.PoidsCargaison) * avionCargo.TempsEmbarquement;

                                Console.WriteLine($"Cargo prêt à embarquer pour {grp.Destination.Nom}. Temps total : {tempsTotal} minutes.");

                                // Changement d'état
                                aeronef.CreerEtatDepuisType(TypeEtat.Embarquement, tempsEmbarquementTotal: tempsTotal);
                                break;
                            }
                        }
                    }
                }
            }
        }

        
        
        
        
    }

    
    
    
    
    
    
}
