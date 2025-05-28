
using SimulateurScenario.Model;
using System.Timers;
using Timer = System.Timers.Timer;


namespace SimulateurScenario.Modele
{
    public class Simulateur
    {
        private Scenario scenario;
        private CaretakerScenario caretaker = new CaretakerScenario();
        private Dictionary<Aeronef, Timer> timersDeplacements;
        
        private System.Timers.Timer simulationTimer;
        private bool simulationEnCours = false;
        private double DureePas { get; set; } = 5;
        
        
        
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
                LancerAnimation(aeronefEnvoye);
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
                    var position = aeronef.PositionActuelle;
                    var clientsATraiter =
                        scenario.GetClients().Where(c => c.position.Distance(position) < 0.1 && !c.estTermine()).ToList();

                    foreach (var client in clientsATraiter)
                    {
                        client.Traiter(aeronef);
                        Console.WriteLine($"Client traite par {aeronef.Nom} a {position.Latitude},{position.Longitude}");
                    }
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
            scenario.HeureActuelle += DureePas;
            // Génère les événement
            
            try
            {
                Console.WriteLine("Generer Evenement");
                scenario.GenererEvenementsSelonFrequence();
                Console.WriteLine("Avancer Etat");
                scenario.AvancerEtatAeronefs(DureePas);
                Console.WriteLine("Fin Avancer Etat");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
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
            Evenement evt = new Evenement
            {
                typeEvenement = TypeEvenement.NouveauClient,
                Aeroports = scenario.m_aeroport
            };
            scenario.NotifierObservateur(evt);
            scenario.VerifierEtDeclencherEmbarquement(scenario.m_aeroport);
        }
        
        public void ChargerScenario(string nomFichier)
        {
            var nouveauScenario = GestionnaireFichierXML.Importer(nomFichier);
            
            foreach (var obs in scenario.GetObservateurs())
            {
                nouveauScenario.Attacher(obs);
            }

            scenario = nouveauScenario;
            foreach (var aeroport in scenario.m_aeroport)
            {
                foreach (var aeronef in aeroport.Aeronefs)
                {
                    // Si le type d’état est non défini, on met Sol par défaut
                    if (!Enum.IsDefined(typeof(TypeEtat), aeronef.typeEtat))
                    {
                        aeronef.typeEtat = TypeEtat.Sol;
                    }

                    // Sécurité : si EtatActuel est null, on le crée
                    if (aeronef.EtatActuel == null)
                    {
                        aeronef.EtatActuel = aeronef.CreerEtatDepuisType(aeronef.typeEtat, null, null);
                        Console.WriteLine("etat change");
                    }
                }
            }
            caretaker.EnregistrerEtatInitial(scenario);
            // notifier la vue
            Evenement evt = new Evenement
            {
                typeEvenement = TypeEvenement.ChargementTermine,
                Aeroports = scenario.m_aeroport // on passe la liste
            };
            
            scenario.NotifierObservateur(evt);
        }
        
        public void ReinitialiserScenario()
        {
            simulationEnCours = false;
            simulationTimer?.Stop();
            timersDeplacements.Clear();

            caretaker.RestaurerEtatInitial(scenario);
            Evenement evt = new Evenement
            {
                typeEvenement = TypeEvenement.NouveauClient,
                Aeroports = scenario.m_aeroport
            };
            scenario.NotifierObservateur(evt);
            Console.WriteLine("Scenario reinitialisé");
           
        }
        
        
        
        
        

        
    }
}
