using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulateurScenario.Model;

namespace SimulateurScenario.Modele
{
    public class Simulateur
    {
        private Scenario scenario;
        
        public Simulateur()
        {
            scenario = new Scenario();
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

        }
        public void AvancerPas() { }
        public void AvancerPlusieursPas(int nombrePas) { }
        public void GenererEvenements()
        {
            GenererPassagers();
            GenererCargos();
           // GenererEvenementUrgence(); // Observation, Secours, Incendie
        }
        public void InitialiserClient()
        {
            GenererPassagers();
            GenererCargos();
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
            
            // notifier la vue
            Evenement evt = new Evenement
            {
                typeEvenement = TypeEvenement.ChargementTermine,
                Aeroports = scenario.m_aeroport // on passe la liste
            };
            
            scenario.NotifierObservateur(evt);
        }
        
        /*public void GenererPassagers()
        {
            Random rnd = new Random();

            // Sélectionner un aéroport de départ
            Aeroport aeroportDepart = scenario.GetAeroportAleatoire();
            Aeroport aeroportDestination = scenario.GetAeroportAleatoireDifferent(aeroportDepart);

            Evenement e = new Evenement
            {
                typeEvenement = TypeEvenement.Passager,
                position = aeroportDepart.Position,
                NombrePassagers = rnd.Next(aeroportDepart.MinPassagers, aeroportDepart.MaxPassagers),
                Destination = aeroportDestination
            };

            Client c = FabriqueClient.Instance.CreerClient(e);
            aeroportDepart.AjouterClient(c);
        }*/
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

        
      /*  public void GenererCargos()
        {
            Random rnd = new Random();
            Aeroport depart = scenario.GetAeroportAleatoire();
            Aeroport dest = scenario.GetAeroportAleatoireDifferent(depart);

            Evenement e = new Evenement
            {
                typeEvenement = TypeEvenement.Cargaison,
                position = depart.Position,
                PoidsCargo = Math.Round(rnd.NextDouble() * 10.0, 2),
                Destination = dest
            };

            Client c = FabriqueClient.Instance.CreerClient(e);
            depart.AjouterClient(c);
        }*/
      
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



        
        

        
    }
}
