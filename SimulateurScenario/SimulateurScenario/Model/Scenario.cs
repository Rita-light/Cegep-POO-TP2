using System;
using System.Collections.Generic;
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
        
        // Garde la dernière heure de génération par type d'événement
        private Dictionary<TypeEvenement, double> dernieresGenerations = new Dictionary<TypeEvenement, double>();
        
        
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
        
        public void GenererCargos()
          {
              Random rnd = new Random();

              foreach (Aeroport depart in GetAeroports())
              {
                  double poidsTotalCible = rnd.Next((int)depart.MinCargaisons, (int)depart.MaxCargaisons + 1);
                  double poidsTotalActuel = 0;

                  while (poidsTotalActuel < poidsTotalCible)
                  {
                      // Générer un poids de cargaison entre 0.5 et 3.0 tonnes
                      double poidsCargaison = Math.Round(0.5 + rnd.NextDouble() * 2.5, 2);

                      // Vérification pour ne pas dépasser le poids cible
                      if (poidsTotalActuel + poidsCargaison > poidsTotalCible)
                      {
                          // Ajuster le dernier poids pour correspondre exactement au poids cible si possible
                          poidsCargaison = Math.Round(poidsTotalCible - poidsTotalActuel, 2);
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
                  }
              }
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
                            VerifierEtDeclencherEmbarquement();
                            break;

                        case TypeEvenement.Cargaison:
                            GenererCargos();
                            VerifierEtDeclencherEmbarquement();
                            break;

                        case TypeEvenement.Observation:
                        case TypeEvenement.Secours:
                        case TypeEvenement.Incendie:
                            GenererEvenementPour(freqEvt.Type);
                            break;
                    }
                }
            }
        }
        
        public void VerifierEtDeclencherEmbarquement()
        {
            foreach (var aeroport in m_aeroport)
            {
                foreach (var aeronef in aeroport.Aeronefs)
                {
                    if (aeronef.EtatActuel == TypeEtat.Sol)
                    {
                        if (aeronef is AvionPassager avionPassager)
                        {
                            var groupe = aeroport.Clients
                                .OfType<Passager>()
                                .GroupBy(c => c.Destination)
                                .Select(g => new { Destination = g.Key, Nombre = g.Count(), Clients = g.ToList() });

                            foreach (var grp in groupe)
                            {
                                if (grp.Nombre >= 0.8 * avionPassager.Capacite)
                                {
                                    // Sélection des clients à embarquer
                                    var aEmbarquer = grp.Clients.Take(avionPassager.Capacite).ToList();
                                    aeroport.Clients.RemoveAll(c => aEmbarquer.Contains(c));
                                    // Déclencher embarquement
                                   // DemarrerEmbarquement(avionPassager, aEmbarquer, grp.Destination, aeroport);
                                   Console.WriteLine("passager près à embarquer");
                                    break;
                                }
                            }
                        }
                        else if (aeronef is AvionCargaison avionCargo)
                        {
                            var groupe = aeroport.Clients
                                .OfType<Cargo>()
                                .GroupBy(c => c.Destination)
                                .Select(g => new { Destination = g.Key, TotalPoids = g.Sum(c => c.PoidsCargaison), Clients = g.ToList() });

                            foreach (var grp in groupe)
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
                                    Console.WriteLine("Cargo près à etre chargé");
                                    //DemarrerEmbarquement(avionCargo, aEmbarquer, grp.Destination, aeroport);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
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
