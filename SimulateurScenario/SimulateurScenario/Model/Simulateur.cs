
using SimulateurScenario.Model;
using System.Timers;
using Timer = System.Timers.Timer;


namespace SimulateurScenario.Modele
{
    public class Simulateur
    {
        private Scenario scenario;
        private Dictionary<Aeronef, Timer> timersDeplacements;
        
        private System.Timers.Timer simulationTimer;
        private bool simulationEnCours = false;
        private double pas { get; set; } = 5;
        
        
        
        public Simulateur()
        {
            scenario = new Scenario();

            timersDeplacements = new Dictionary<Aeronef, Timer>();

            
        }
//Traitement des événements/////////////////////////////////////////////////////////////////////////////////////////////
        public bool TraiterEvenement(Evenement evenement)
        {
            Aeronef aeronefEnvoye = scenario.TraiterEvenement(evenement);

            if (aeronefEnvoye != null)
            {
                OnAeronefEnvoye?.Invoke(aeronefEnvoye);
                return true;
            }
            return false;
        }

        private void LancerAnimation(Aeronef aeronef)
        {
            var timer = new Timer(100);
            timer.Elapsed += (sender, e) =>
            {
                DeplacerAeronef(aeronef);
                NotifierPositionChanged(aeronef);

                if (EstArrive(aeronef))
                {
                    aeronef.ChangerEtat(TypeEtat.Vol);
                    timer.Stop();
                    timer.Dispose();
                    timersDeplacements.Remove(aeronef);
                    NotifierArrivee(aeronef);
                }
            };
            timersDeplacements[aeronef] = timer;
            timer.Start();
        }

        private void DeplacerAeronef(Aeronef aeronef)
        {
            double distance = aeronef.PositionActuelle.Distance(aeronef.PositionDestination);
            double deplacement = aeronef.Vitesse * 0.1 / 360;

            if (distance <= deplacement)
            {
                aeronef.PositionActuelle = aeronef.PositionDestination;
            }
            else
            {
                double ratio = deplacement / distance;
                double dx = (aeronef.PositionDestination.Longitude - aeronef.PositionActuelle.Longitude) * ratio;
                double dy = (aeronef.PositionDestination.Latitude - aeronef.PositionActuelle.Latitude) * ratio;
                aeronef.PositionActuelle = new Position(aeronef.PositionActuelle.Latitude + dy, aeronef.PositionActuelle.Longitude + dx);
            }
        }

        private bool EstArrive(Aeronef aeronef)
        {
            return aeronef.PositionActuelle.Distance(aeronef.PositionDestination) < 0.1;
        }
        
        public event Action<Aeronef> PositionChanged;
        public event Action<Aeronef> Arrivee;
        
        public event Action<Aeronef> OnAeronefEnvoye;

        private void NotifierArrivee(Aeronef aeronef)
        {
            Arrivee?.Invoke(aeronef);
        }
        private void NotifierPositionChanged(Aeronef aeronef)
        {
            PositionChanged?.Invoke(aeronef);
        }

        
        
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////        
        
        public Scenario GetScenario() => scenario;
        
        private void SimulationTimer_Tick(object sender, EventArgs e)
        {
            AvancerUnPas(); // ou Appeler AvancerPlusieursPas(1)
        }

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
            scenario.GenererEvenementPour(TypeEvenement.Incendie);
            scenario.GenererEvenementPour(TypeEvenement.Secours);
            scenario.GenererEvenementPour(TypeEvenement.Observation);
            
        }
        
        public void LancerSimulationAuto()
        {
            simulationTimer = new System.Timers.Timer();
            simulationTimer.Interval = 3000; 
            simulationTimer.Elapsed += (s, e) => AvancerUnPas();
            simulationTimer.Start();
        }
        
        public void ArreterSimulation()
        {
            simulationTimer?.Stop();
            simulationTimer?.Dispose();
            simulationTimer = null;
        }
        
        
        public void AvancerUnPas()
        {
            scenario.HeureActuelle += pas;
            // Génère les événement
            scenario.GenererEvenementsSelonFrequence();
            
        }

        public void AvancerPlusieursPas(int nombrePas)
        {
            for (int i = 0; i < nombrePas; i++)
            {
                AvancerUnPas();
            }
        }
        
        public void InitialiserClient()
        {
            scenario.GenererPassagers();
            scenario.GenererCargos();
            scenario.VerifierEtDeclencherEmbarquement();
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
        
        /*public void ReinitialiserScenario()
        {
            caretaker.RestaurerEtatInitial(scenario);
            // notifier le form
            Evenement evt = new Evenement
            {
                typeEvenement = TypeEvenement.ChargementTermine,
                Aeroports = scenario.m_aeroport
            };
            scenario.NotifierObservateur(evt);
        }*/
        
       







        
        

        
    }
}
