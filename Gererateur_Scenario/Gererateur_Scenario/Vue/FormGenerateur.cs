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
            m_controleur = new ControleurGenerateur();
            m_controleur.EnregistrerObservateur(this);
        }
        
        
        private void btnAeroport_Click(object sender, EventArgs e)
        {
            var data = new Dictionary<string, string>()
            {
                { "Nom", nomAeroport.Text },
                { "Latitude", position_latitude.Text },
                { "Longitude", position_longitude.Text },
                { "MinPassagers", minPassager.Text },
                { "MaxPassagers", maxPassager.Text },
                { "MinCargaisons", minCargaison.Text },
                { "MaxCargaisons", maxCargaison.Text }
            };

            m_controleur.AjouterAeroport(data);
        }
        
        public void AfficherScenario() { }
       
        public void AfficherAeroports() { }
        public void AfficherAeronefs() { }
        public void AfficherEvenements() { }

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

        public void MettreAJour()
        {
            MettreAJourVue();
        }

        public void MettreAJourVue()
        {
            AfficherAeroports();
            AfficherAeronefs();
            AfficherEvenements();
        }

        private void btnCharger_Click(object sender, EventArgs e)
        {
            // 1. Boîte de dialogue pour sélectionner un fichier XML
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers XML (*.xml)|*.xml";
            openFileDialog.Title = "Importer un scénario";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string cheminFichier = openFileDialog.FileName;

                try
                {
                    // 2. Appel au contrôleur pour charger le scénario
                    m_controleur.ChargerScenario(cheminFichier);

                    // 3. Mise à jour de la vue après chargement réussi
                    MettreAJourVue();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'importation du scénario : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
    }
}
