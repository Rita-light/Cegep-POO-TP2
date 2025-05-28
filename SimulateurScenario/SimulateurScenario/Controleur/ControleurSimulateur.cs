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
        private FacadeSimulateur facade;
        private form_Simulateur formSimulateur;

        public ControleurSimulateur(form_Simulateur form)
        {
            this.formSimulateur = form;
            this.formSimulateur.SetControleur(this);
            this.facade = new FacadeSimulateur();
            facade.AttacherObservateur(formSimulateur);
            facade.OnPositionChanged += MettreAJourVue;
            facade.OnAeronefEnvoye += LancerDeplacement;
        }
        
        public void DemarrerSimulationAuto() => facade.LancerSimulationAuto();

        public void ArreterSimulation() => facade.ArreterSimulation();

        public void AvancerUnPas() => facade.AvancerUnPas();

        public void AvancerPlusieursPas(int nombrePas) => facade.AvancerPlusieursPas(nombrePas);

        public void TraiterEvenement(Evenement evenement)
        {
            facade.TraiterEvenement(evenement);
            evenement.EstTermine = true;
            evenement.NotifierObservateurs();
        }

        public void LancerDeplacement(Aeronef aeronef)
        {
            formSimulateur.LancerDeplacement(aeronef);       
        }

        private void MettreAJourVue(Aeronef aeronef)
        {
            if (formSimulateur.InvokeRequired)
            {
                formSimulateur.Invoke(new Action(() => MettreAJourVue(aeronef)));
                return;
            }

            MettreAJourCarte(aeronef);
        }

        private void MettreAJourCarte(Aeronef aeronef)
        {
            PictureBox pic = formSimulateur.GetMarqueurAeronef(aeronef);
            if (pic != null)
            {
                Point positionPixel = Position.ConvertirCoordonneesEnPixels(aeronef.PositionActuelle);
                pic.Location = positionPixel;
            }
        }

        public void Initialiser()
        {
            facade.DemarrerSimulation();
        }

        public void ChargerScenario(string cheminFichier)
        {
            facade.ChargerScenario(cheminFichier);
            Initialiser();
        }
        
        public void Reinitialiserscenario()
        {
            facade.Reinitialiserscenario();
        }
    }
}
