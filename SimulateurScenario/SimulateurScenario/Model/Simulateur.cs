
using SimulateurScenario.Model;

using System.Timers;

namespace SimulateurScenario.Modele
{
    public class Simulateur
    {
        private Scenario scenario;
        
        private System.Timers.Timer simulationTimer;
        private bool simulationEnCours = false;
        private double pas { get; set; } = 5;
        
        
        
        public Simulateur()
        {
            scenario = new Scenario();
            
        }
        
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
        
       
        
        

        public void TraiterEvenement(Evenement evenement)
        {
            scenario.TraiterEvenement(evenement);
        }
       







        
        

        
    }
}
