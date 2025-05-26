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

        public void Notifier(Evenement evenement) { }
    }
}
