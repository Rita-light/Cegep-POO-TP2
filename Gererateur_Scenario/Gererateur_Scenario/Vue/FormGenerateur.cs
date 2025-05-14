using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gererateur_Scenario.Controle;

namespace Gererateur_Scenario.Vue
{
    public partial class FormGenerateur : Form, IObservateur
    {
        private ControleurGenerateur m_controleur;
        
        public FormGenerateur()
        {
            InitializeComponent();
        }
        
        public void AfficherScenario() { }
        public void MettreAJourVue() { }
        public void AfficherAeroports() { }
        public void AfficherAeronefs() { }
        public void AfficherEvenements() { }

        private void AjouterAeroport_Click(object sender, EventArgs e) { }
        private void ModifierAeroport_Click(object sender, EventArgs e) { }
        private void SupprimerAeroport_Click(object sender, EventArgs e) { }

        private void AjouterAeronef_Click(object sender, EventArgs e) { }
        private void ModifierAeronef_Click(object sender, EventArgs e) { }
        private void SupprimerAeronef_Click(object sender, EventArgs e) { }

        private void AjouterEvenement_Click(object sender, EventArgs e) { }
        private void ModifierEvenement_Click(object sender, EventArgs e) { }
        private void SupprimerEvenement_Click(object sender, EventArgs e) { }

        private void ImporterScenario_Click(object sender, EventArgs e) { }
        private void ExporterScenario_Click(object sender, EventArgs e) { }

        public void MettreAJour() { }
    }
}
