using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public class Scenario : ISujet
    {
        public List<Aeroport> m_aeroport { get; set; }
        public List<FrequenceEvenement> m_frequence { get; set; } =  new List<FrequenceEvenement>();
        private List<IObservateur> m_observateurs = new List<IObservateur>();
        private List<Client> clientsEvenements = new List<Client>();
        public double HeureActuelle { get; set; } = 0;
        
        private Dictionary<TypeEvenement, double> dernieresGenerations = new Dictionary<TypeEvenement, double>();
        public List<Aeronef> aeronefsAAjouter = new();
        
        private static Random rnd = new Random();
        public Scenario()
        {
            m_aeroport = new List<Aeroport>();
            m_frequence = new List<FrequenceEvenement>();
            m_observateurs = new List<IObservateur>();
        }
        
        public void Attacher(IObservateur obs)
        {
            if (!m_observateurs.Contains(obs))
            {
                m_observateurs.Add(obs);
                Console.WriteLine("observateur enregistré");
            }
        }
        public void Detacher(IObservateur obs) => m_observateurs.Remove(obs);

        public void NotifierObservateur(Evenement evenement)
        {
            foreach (var obs in m_observateurs)
            {
                obs.Notifier(evenement);
            }
        }
        public void AjouterEvenementClient(Client c)
        {
            clientsEvenements.Add(c);
        }

        public bool DoitGenerer(TypeEvenement type, double frequence)
        {
            if (!dernieresGenerations.ContainsKey(type))
            {
                dernieresGenerations[type] = HeureActuelle;
                return true;
            }

            double derniereHeure = dernieresGenerations[type];
            if ((HeureActuelle - derniereHeure) >= frequence)
            {
                dernieresGenerations[type] = HeureActuelle;
                return true;
            }

            return false;
        }

/*        public void TraiterEvenement(Evenement evenement)
        {
            Aeroport aeroport = GetAeroportProche(evenement.position);

            if (aeroport == null)
            {
                return;
            };

            Aeronef aeronef = aeroport.Aeronefs.FirstOrDefault(a => evenement.typeEvenement 
                switch
            {
                TypeEvenement.Cargaison => a is AvionCargaison,
                TypeEvenement.Incendie => a is AvionCiterne,
                TypeEvenement.Secours => a is AvionSecours,
                _ => false
            });
            if (aeronef == null)
            {
                return;
            }
            if (aeronef.EtatActuel == TypeEtat.Sol)
            {
                aeroport.SaveLastAeronef(aeronef);
                aeronef.ChangerEtat(TypeEtat.Vol);
                aeronef.Avancer(evenement.position);
                NotifierObservateur(evenement);
            }
        }
*/
        
//Traitement des évènements/////////////////////////////////////////////////////////////////////////////////////////////
        public Aeroport GetAeroportProche(Position coordonnees)
        {
            Aeroport aeroportProche = null;
            double distanceMin = double.MaxValue;
            
            foreach (var aeroport in m_aeroport)
            {
                double distance = aeroport.Position.Distance(coordonnees);
                if (distance < distanceMin)
                {
                    distanceMin = distance;
                    aeroportProche = aeroport;
                }
            }
            return aeroportProche;
        }

        public Aeronef TraiterEvenement(Evenement evenement)
        {
            Aeroport aeroport = GetAeroportProche(evenement.position);
            if(aeroport == null)
                return null;

            Aeronef aeronef = aeroport.GetAeronefDisponible(evenement.typeEvenement);
            if (aeronef == null)
            {
             return AutreAeroport(evenement, aeroport); ;   
            }
            
            aeroport.EnvoyerAeronef(aeronef, evenement.position);
            return aeronef;
        }

        private Aeronef AutreAeroport(Evenement evenement, Aeroport checkedAeroport)
        {
            var aeroports = m_aeroport
                .Where(a => a != checkedAeroport)
                .OrderBy(a => a.Position.Distance(evenement.position));
            
            foreach (var aeroport in aeroports)
            {
                Aeronef aeronef = aeroport.GetAeronefDisponible(evenement.typeEvenement);
                if (aeronef != null)
                {
                    aeroport.EnvoyerAeronef(aeronef, evenement.position);
                    return aeronef;
                }
            }
            return null;
        }
/// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        
        
        public List<IObservateur> GetObservateurs()
        {
            return m_observateurs;
        }
        public List<Aeroport> GetAeroports() => m_aeroport;
        
        public Aeroport GetAeroportAleatoire()
        {
            if (m_aeroport == null || m_aeroport.Count == 0)
                throw new InvalidOperationException("Aucun aéroport disponible.");

            int index = rnd.Next(m_aeroport.Count);
            return m_aeroport[index];
        }
        
        public Aeroport GetAeroportAleatoireDifferent(Aeroport aeroportExclu)
        {
            if (m_aeroport == null || m_aeroport.Count < 2)
                throw new InvalidOperationException("Pas assez d’aéroports pour choisir un différent.");

            Aeroport aeroportChoisi;
            do
            {
                aeroportChoisi = GetAeroportAleatoire();
            } while (aeroportChoisi == aeroportExclu);

            return aeroportChoisi;
        }
        
         public void GenererPassagers()
        {
            Console.WriteLine("generer pasagers 1");
            Random rnd = new Random();

            foreach (Aeroport aeroportDepart in GetAeroports())
            {
                // Générer un nombre aléatoire de passagers pour cet aéroport
                int nbPassagers = rnd.Next(aeroportDepart.MinPassagers, aeroportDepart.MaxPassagers + 1);

                for (int i = 0; i < nbPassagers; i++)
                {
                    // Destination aléatoire différente du départ
                    Aeroport aeroportDestination = GetAeroportAleatoireDifferent(aeroportDepart);

                    Evenement e = new Evenement
                    {
                        typeEvenement = TypeEvenement.Passager,
                        position = aeroportDepart.Position,
                        NombrePassagers = 1, // 1 passager par client
                        Destination = aeroportDestination
                    };

                    Client c = FabriqueClient.Instance.CreerClient(e);
                    aeroportDepart.AjouterClient(c);
                }
            }
        }
        
        [SuppressMessage("ReSharper.DPA", "DPA0000: DPA issues")]
        public void GenererCargos()
        {
            Console.WriteLine("Début de la génération des cargaisons...");
            Random rnd = new Random();

            foreach (Aeroport depart in GetAeroports())
            {
                double poidsRestant = depart.MaxCargaisons - depart.GetPoidsActuel();
                if (poidsRestant <= 0) continue; 

                double poidsTotalCible = Math.Min(poidsRestant, rnd.Next((int)depart.MinCargaisons, (int)depart.MaxCargaisons + 1));
                double poidsTotalActuel = 0;

                while (poidsTotalActuel < poidsTotalCible)
                {
                    double poidsRestantBoucle = poidsTotalCible - poidsTotalActuel;
                    if (poidsRestantBoucle < 0.5)
                    {
                        poidsTotalActuel = poidsTotalCible; // Forcer la sortie
                        break;
                    }
                    
                    // Générer un poids de cargaison entre 0.5 et 3.0 tonnes
                    double poidsCargaison = Math.Round(0.5 + rnd.NextDouble() * 2.5, 2);

                    // Ajuster le dernier poids pour correspondre exactement au poids cible si nécessaire
                    if (poidsCargaison > poidsRestantBoucle)
                    {
                        poidsCargaison = Math.Round(poidsRestantBoucle, 2);
                    }

                    Aeroport dest = GetAeroportAleatoireDifferent(depart);

                    Evenement e = new Evenement
                    {
                        typeEvenement = TypeEvenement.Cargaison,
                        position = depart.Position,
                        PoidsCargo = poidsCargaison,
                        Destination = dest
                    };

                    Client c = FabriqueClient.Instance.CreerClient(e);
                    depart.AjouterClient(c);
                    poidsTotalActuel += poidsCargaison;

                    // Nettoyage de l'événement après utilisation
                    e = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    
                }
            }
            Console.WriteLine("Fin de la génération des cargaisons.");
        }
        
        public void GenererEvenementPour(TypeEvenement type)
        {
            Random rnd = new Random();
            Evenement e = new Evenement();

            // Spécificité selon le type
            if (type == TypeEvenement.Secours)
            {
                e = new Evenement
                {
                    typeEvenement = TypeEvenement.Secours,
                    position = Position.GenererPositionAleatoire()
                };

                Client client = FabriqueClient.Instance.CreerClient(e);
                AjouterEvenementClient(client);
                NotifierObservateur(e);
            }
            
            if (type == TypeEvenement.Observation)
            {
                e = new Evenement
                {
                    typeEvenement = TypeEvenement.Observation,
                    position = Position.GenererPositionAleatoire()
                };

                Client client = FabriqueClient.Instance.CreerClient(e);
                AjouterEvenementClient(client);
                NotifierObservateur(e);
            }
            
            if (type == TypeEvenement.Incendie)
            {
                 e = new Evenement
                {
                    typeEvenement = TypeEvenement.Incendie,
                    position = Position.GenererPositionAleatoire(),
                    Intensite = rnd.Next(1, 3) // Intensité entre 1 et 10
                };

                Client client = FabriqueClient.Instance.CreerClient(e);
                AjouterEvenementClient(client);
                NotifierObservateur(e);
            }

        }
        
        public void GenererEvenementsSelonFrequence()
        {
            foreach (FrequenceEvenement freqEvt in m_frequence)
            {
                // Si l'heure actuelle est un multiple de la fréquence, on génère l'événement
                if (DoitGenerer(freqEvt.Type, freqEvt.Frequence))
                {
                    switch (freqEvt.Type)
                    {
                        case TypeEvenement.Passager:
                            GenererPassagers();
                            break;

                        case TypeEvenement.Cargaison:
                            GenererCargos();
                            break;

                        case TypeEvenement.Observation:
                        case TypeEvenement.Secours:
                        case TypeEvenement.Incendie:
                            GenererEvenementPour(freqEvt.Type);
                            break;
                    }
                }
            }
            VerifierEtDeclencherEmbarquement(m_aeroport);
            Console.WriteLine("Mettre à jours vue");
            Evenement evt = new Evenement
            {
                typeEvenement = TypeEvenement.NouveauClient,
                Aeroports = m_aeroport
            };
            NotifierObservateur(evt);
            
        }
        
       public void VerifierEtDeclencherEmbarquement(List<Aeroport> aeroports)
        {
            Console.WriteLine("Début vérification embarquqtion");
            
            try
            {
                foreach (var aeroport in aeroports)
                {
                    foreach (var aeronef in aeroport.Aeronefs)
                    {
                        if (aeronef.EtatActuel.GetTypeEtat() != TypeEtat.Sol){
                            //Console.WriteLine($"[INFO] Aéronef {aeronef.Nom}ignoré car son état est : {aeronef.EtatActuel.GetTypeEtat()}, {aeronef.Nom}");
                            continue;
                        }

                        // Console.WriteLine($"Vérification de l'aéronef {aeronef.Nom} au sol.");

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

                                    var destinationAeroport = grp.Destination;
                                    if (destinationAeroport == null)
                                    {
                                        Console.WriteLine($"[Erreur] Destination {grp.Destination.Nom} introuvable !");
                                        continue;
                                    }

                                    // Mise à jour des positions
                                    avionPassager.PositionActuelle = aeroport.Position;
                                    avionPassager.PositionDepart = aeroport.Position;
                                    avionPassager.Destination = destinationAeroport;


                                    // Calcul du temps d'embarquement
                                    avionPassager.nombreClientEmbarque = aEmbarquer.Count;
                                    double tempsTotal = aEmbarquer.Count * avionPassager.TempsEmbarquement;

                                    Console.WriteLine($"Passagers prêts à embarquer pour {grp.Destination.Nom}. Temps total : {tempsTotal} minutes.");

                                    // Changement d'état
                                    aeronef.ChangerEtat(TypeEtat.Embarquement,
                                        tempsEmbarquementTotal: tempsTotal);
                                    Console.WriteLine($"Aeronef changé{aeronef.Nom} : {aeronef.EtatActuel.GetTypeEtat()}");
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

                                    var destinationAeroport = grp.Destination;
                                    if (destinationAeroport == null)
                                    {
                                        Console.WriteLine($"[Erreur] Destination {grp.Destination.Nom} introuvable !");
                                        continue;
                                    }

                                    // Mise à jour des positions
                                    avionCargo.PositionActuelle = aeroport.Position;
                                    avionCargo.PositionDepart = aeroport.Position;
                                    avionCargo.Destination = destinationAeroport;


                                    // Calcul du temps d’embarquement
                                    double tempsTotal = aEmbarquer.Sum(c => c.PoidsCargaison) *
                                                        avionCargo.TempsEmbarquement;
                                    avionCargo.nombreTonneCharge = aEmbarquer.Sum(c => c.PoidsCargaison);

                                    Console.WriteLine(
                                        $"Cargo prêt à embarquer pour {grp.Destination.Nom}. Temps total : {tempsTotal} minutes.");

                                    // Changement d'état
                                    aeronef.CreerEtatDepuisType(TypeEtat.Embarquement,
                                        tempsEmbarquementTotal: tempsTotal);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
       
        public void AvancerEtatAeronefs(double dureePas)
        {
            // Liste des changements d’aéroport à faire après
            
            
            foreach (var aeroport in m_aeroport)
            {
                var aeronefs = aeroport.Aeronefs.ToList();
                foreach (var aeronef in aeroport.Aeronefs)
                {
                    Console.WriteLine($"Avancer Etat de {aeronef.Nom}");
                    aeronef.EtatActuel.Avancer(dureePas, aeronef, this);
                }
            }

            foreach (var aeronef in aeronefsAAjouter)
            {
                ChangerAeroport(aeronef);
               
            }
            aeronefsAAjouter.Clear();

            var enVol = m_aeroport.SelectMany(a => a.Aeronefs).Where(a => a.EtatActuel is EtatVol).ToList();
            
            
        }
        
        
        
        public void ChangerAeroport(Aeronef aeronef)
        {
            Aeroport aeroportDestination = aeronef.Destination;
            
            Aeroport aeroportActuel = m_aeroport.FirstOrDefault(a => a.Aeronefs.Contains(aeronef));

            if (aeroportActuel != null)
            {
                aeroportActuel.Aeronefs.Remove(aeronef);
            }
            
            // Ajouter à l’aéroport de destination
            aeroportDestination.AjouterAeronef(aeronef);
            Console.WriteLine("Appartenance Aeroport changé");            
        }

        
        
        public ScenarioMemento CreateMemento()
        {
            return new ScenarioMemento(m_aeroport);
        }

        public void RestoreMemento(ScenarioMemento memento)
        {
            m_aeroport = memento.Aeroports.Select(a => a.Clone()).ToList();
        }
        
        
    }
}
