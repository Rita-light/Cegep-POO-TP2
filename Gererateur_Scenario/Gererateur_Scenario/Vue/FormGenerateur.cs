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
        
        public void SetControleur(ControleurGenerateur controleur)
        {
            m_controleur = controleur;
            m_controleur.EnregistrerObservateur(this);
        }
        
        
        private void btnAeroport_Click(object sender, EventArgs e)
        {
            string nom = nomAeroport.Text.Trim();
            var data = new Dictionary<string, string>()
            {
                { "Nom", nomAeroport.Text.Trim() },
                { "Latitude", position_latitude.Text.Trim() },
                { "Longitude", position_longitude.Text.Trim() },
                { "MinPassagers", minPassager.Text.Trim() },
                { "MaxPassagers", maxPassager.Text.Trim() },
                { "MinCargaisons", minCargaison.Text.Trim() },
                { "MaxCargaisons", maxCargaison.Text.Trim() }
            };
            
            // --- Vérification si le nom est vide ---
            if (string.IsNullOrWhiteSpace(nom))
            {
                MessageBox.Show("Le nom de l'aéroport est requis.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // --- Vérification de l'unicité du nom ---
            foreach (string item in listAeroport.Items)
            {
                if (item.StartsWith(nom + " ("))
                {
                    MessageBox.Show("Un aéroport avec ce nom existe déjà.", "Doublon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            
            
            
            // Vérifier si les champs numériques sont valides
            if (!int.TryParse(data["MinPassagers"], out int minPassagers) ||
                !int.TryParse(data["MaxPassagers"], out int maxPassagers) ||
                !double.TryParse(data["MinCargaisons"], out double minCargaisons) ||
                !double.TryParse(data["MaxCargaisons"], out double maxCargaisons) ||
                !double.TryParse(data["Latitude"], out double latitude) ||
                !double.TryParse(data["Longitude"], out double longitude))
            {
                MessageBox.Show("Veuillez entrer des valeurs valides pour tous les champs numériques.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // Vérifier que Max > Min pour les passagers et cargaisons
            if (maxPassagers <= minPassagers)
            {
                MessageBox.Show("Le nombre maximal de passagers doit être supérieur au nombre minimal.", "Erreur logique", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (maxCargaisons <= minCargaisons)
            {
                MessageBox.Show("La cargaison maximale doit être supérieure à la cargaison minimale.", "Erreur logique", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            

            m_controleur.AjouterAeroport(data);
        }
        
        public void AfficherScenario() { }

        public void AfficherAeroports()
        {
            listAeroport.Items.Clear();
            List<String> aeroport = m_controleur.ObtenirListeAeroports();
            
            // Afficher dans la listview
            foreach (var ligne in aeroport)
            {
                string[] parties = ligne.Split('|');
                
                string nom = parties[0];
                double latitude = double.Parse(parties[1]);
                double longitude = double.Parse(parties[2]);
                int minPassagers = int.Parse(parties[3]);
                int maxPassagers = int.Parse(parties[4]);
                double minCargaisons = double.Parse(parties[5]);
                double maxCargaisons = double.Parse(parties[6]);
                
                    // Direction (Nord/Sud, Est/Ouest)
                string latDirection = latitude >= 0 ? "N" : "S";
                string longDirection = longitude >= 0 ? "E" : "O";

                string texteAffichage = $"{nom} ({Position.ConvertirEnDMS(latitude, true)}, {Position.ConvertirEnDMS(longitude, false)}) " +
                                        $"MinPassagers : {minPassagers}, MaxPassagers : {maxPassagers}, " +
                                        $"MinCargaisons : {minCargaisons}, MaxCargaisons : {maxCargaisons}";

                listAeroport.Items.Add(texteAffichage);
            }
        }
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
            Console.WriteLine("Debut mise à jour");
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

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            //m_controleur.GenererScenario();
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Fichier XML (*.xml)|*.xml";
                saveDialog.Title = "Enregistrer le scénario";
                saveDialog.FileName = "Scenario.xml";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string cheminFichier = saveDialog.FileName;
                    m_controleur.GenererScenario(cheminFichier); // <-- chemin fourni à la couche contrôle
                    MessageBox.Show("Scénario enregistré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
