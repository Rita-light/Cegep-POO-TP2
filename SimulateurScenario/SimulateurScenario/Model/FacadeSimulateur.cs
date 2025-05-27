using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulateurScenario.Controleur;
using SimulateurScenario.Modele;

namespace SimulateurScenario.Model
{
    public class FacadeSimulateur 
    {
        private Simulateur simulateur;
        //private ControleurSimulateur controleur;
        
        public FacadeSimulateur()
        {
            this.simulateur = new Simulateur();
            simulateur.PositionChanged += (aeronef) => OnPositionChanged?.Invoke(aeronef);
            simulateur.OnAeronefEnvoye += (aeronef) => OnAeronefEnvoye?.Invoke(aeronef);
        }

        public bool TraiterEvenement(Evenement evenement)
        {
            bool succes = simulateur.TraiterEvenement(evenement);

            if (!succes)
            {
                OnMessage?.Invoke($"Aucun aéronef disponible pour {evenement.typeEvenement}");
            }
            return succes;
        }
        
        public event Action<Aeronef> OnPositionChanged;
        public event Action<string> OnMessage;
        public event Action<Aeronef> OnAeronefEnvoye;
        
        public void AttacherObservateur(IObservateur observateur)
        {
            // Attache du contrôleur comme observateur au scénario
            simulateur.GetScenario().Attacher(observateur);
        }
        
        public void ChargerScenario(string cheminFichier)
        {
            simulateur.ChargerScenario(cheminFichier);
        }

        
        public void DemarrerSimulation()
        {
            simulateur.DemarrerSimulation();
        }


        public void LancerSimulationAuto() => simulateur.LancerSimulationAuto();

        public void ArreterSimulation() => simulateur.ArreterSimulation();

        public void AvancerUnPas() => simulateur.AvancerUnPas();

        public void AvancerPlusieursPas(int nbPas) => simulateur.AvancerPlusieursPas(nbPas);

       /* public void TraiterEvenement(Evenement evenement)
        {
            simulateur.TraiterEvenement(evenement);
        }*/
        

        
        public void CreerClient(Evenement evenement) { }
        public void AjouterClient() { }
        public void CreerAeronef() { }

    }
}
