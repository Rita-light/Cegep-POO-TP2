using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulateurScenario.Model;
using Timer = System.Windows.Forms.Timer;

namespace SimulateurScenario.Modele
{
    public class Simulateur
    {
        private CaretakerScenario caretaker;
        private Scenario scenario;
        
        public Simulateur()
        {
            scenario = new Scenario();
            caretaker = new CaretakerScenario();
        }
        
        public Scenario GetScenario() => scenario;

        public void DemarrerSimulation()
        {
            InitialiserClient();
            Evenement evt = new Evenement
            {
                typeEvenement = TypeEvenement.NouveauClient,
                Aeroports = scenario.m_aeroport
            };
            scenario.NotifierObservateur(evt);
            //test
            GenererEvenementPour(TypeEvenement.Incendie);
            GenererEvenementPour(TypeEvenement.Secours);
            GenererEvenementPour(TypeEvenement.Observation);


        }
        public void AvancerPas() { }
        public void AvancerPlusieursPas(int nombrePas) { }
        public void GenererEvenements()
        {
            GenererPassagers();
            GenererCargos();
            VerifierEtDeclencherEmbarquement();
           // GenererEvenementUrgence(); // Observation, Secours, Incendie
        }
        public void InitialiserClient()
        {
            GenererPassagers();
            GenererCargos();
            VerifierEtDeclencherEmbarquement();
        }

        public void AfficherVols() { }

        public void ChargerScenario(string nomFichier)
        {
            var nouveauScenario = GestionnaireFichierXML.Importer(nomFichier);
            
            foreach (var obs in scenario.GetObservateurs())
            {
                nouveauScenario.Attacher(obs);
            }

            scenario = nouveauScenario;
           //caretaker.EnregistrerEtatInitial(scenario);
            
            // notifier la vue
            Evenement evt = new Evenement
            {
                typeEvenement = TypeEvenement.ChargementTermine,
                Aeroports = scenario.m_aeroport // on passe la liste
            };
            
            scenario.NotifierObservateur(evt);
        }
        
        public void GenererPassagers()
        {
            Random rnd = new Random();

            foreach (Aeroport aeroportDepart in scenario.GetAeroports())
            {
                // Générer un nombre aléatoire de passagers pour cet aéroport
                int nbPassagers = rnd.Next(aeroportDepart.MinPassagers, aeroportDepart.MaxPassagers + 1);

                for (int i = 0; i < nbPassagers; i++)
                {
                    // Destination aléatoire différente du départ
                    Aeroport aeroportDestination = scenario.GetAeroportAleatoireDifferent(aeroportDepart);

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

              foreach (Aeroport depart in scenario.GetAeroports())
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

                      Aeroport dest = scenario.GetAeroportAleatoireDifferent(depart);

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
                scenario.AjouterEvenementClient(client);
                scenario.NotifierObservateur(e);
            }
            
            if (type == TypeEvenement.Observation)
            {
                e = new Evenement
                {
                    typeEvenement = TypeEvenement.Observation,
                    position = Position.GenererPositionAleatoire()
                };

                Client client = FabriqueClient.Instance.CreerClient(e);
                scenario.AjouterEvenementClient(client);
                scenario.NotifierObservateur(e);
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
                scenario.AjouterEvenementClient(client);
                scenario.NotifierObservateur(e);
            }

        }
        
        public void GenererEvenementsSelonFrequence(double heureActuelle)
        {
            foreach (FrequenceEvenement freqEvt in scenario.m_frequence)
            {
                // Si l'heure actuelle est un multiple de la fréquence, on génère l'événement
                if (freqEvt.Frequence > 0 && heureActuelle % freqEvt.Frequence == 0)
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
        }

        
        public void VerifierEtDeclencherEmbarquement()
        {
            foreach (var aeroport in scenario.m_aeroport)
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
        
        public void ReinitialiserScenario()
        {
            caretaker.RestaurerEtatInitial(scenario);
            // notifier le form
            Evenement evt = new Evenement
            {
                typeEvenement = TypeEvenement.ChargementTermine,
                Aeroports = scenario.m_aeroport
            };
            scenario.NotifierObservateur(evt);
        }

        public void TraiterEvenement(Evenement evenement)
        {
            scenario.TraiterEvenement(evenement);
        }
       







        
        

        
    }
}
