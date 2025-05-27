using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulateurScenario.Model;

namespace SimulateurScenario.Controleur
{
    public class ControleurSimulateur
    {
        private FacadeSimulateur facadeSimulateur;
        private form_Simulateur formSimulateur;

        public ControleurSimulateur(form_Simulateur form)
        {
            this.formSimulateur = form;
            this.formSimulateur.SetControleur(this);
            this.facadeSimulateur = new FacadeSimulateur();
            facadeSimulateur.AttacherObservateur(formSimulateur);
        }

        public void Initialiser()
        {
            facadeSimulateur.DemarrerSimulation();
        }
        
        public void ChargerScenario(string cheminFichier)
        {
            facadeSimulateur.ChargerScenario(cheminFichier);
            Initialiser();
        }
        
        public void DemarrerSimulationAuto() => facadeSimulateur.LancerSimulationAuto();

        public void ArreterSimulation() => facadeSimulateur.ArreterSimulation();

        public void AvancerUnPas() => facadeSimulateur.AvancerUnPas();

        public void AvancerPlusieursPas(int nombrePas) => facadeSimulateur.AvancerPlusieursPas(nombrePas);

        public void TraiterEvenement(Evenement evenement)
        {
            if (evenement == null)
                return;
            facadeSimulateur.TraiterEvenement(evenement);
        }

        public void Notifier(Evenement evenement) { }
    }
}
