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

        public void MettreAJour()
        {
            Console.WriteLine("Debut mise à jour");
            MettreAJourVue();
        }

        public void MettreAJourVue()
        {
            AfficherAeroports();
            AfficherAeronefs();
            ReinitialiserTextBox();
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

        private void modifierAeroport_Click(object sender, EventArgs e)
        {
            // Vérifie qu’un aéroport est sélectionné
            if (listAeroport.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner un aéroport à modifier.");
                return;
            }

            try
            {
                // Récupérer l'ancien nom à partir de la ligne affichée dans la ListView
                string ligneAffichee = listAeroport.SelectedItem.ToString();
                string ancienNom = ligneAffichee.Split('(')[0].Trim();

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
                    string nomItem = item.Split('(')[0].Trim();

                    if (nomItem.Equals(nom, StringComparison.OrdinalIgnoreCase) && !nom.Equals(ancienNom, StringComparison.OrdinalIgnoreCase))
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

                m_controleur.ModifierAeroport(ancienNom, data);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue : " + ex.Message);
            }
        }

        private void listAeroport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listAeroport.SelectedIndex == -1) return;

            // Récupère le nom affiché dans la listview
            string ligneAffichee = listAeroport.SelectedItem.ToString();

            // Le nom est avant le premier espace, ou avant la première parenthèse
            string nomSelectionne = ligneAffichee.Split('(')[0].Trim();

            // Obtenir la liste brute depuis le contrôleur
            List<string> listeAeroports = m_controleur.ObtenirListeAeroports();

            // Trouver la ligne correspondante dans la liste brute
            string ligneBrute = listeAeroports.FirstOrDefault(a => a.StartsWith(nomSelectionne + "|"));

            if (ligneBrute == null)
            {
                MessageBox.Show("Impossible de retrouver les informations de cet aéroport.");
                return;
            }

            // Extraire les valeurs et les placer dans les TextBox
            string[] parties = ligneBrute.Split('|');

            nomAeroport.Text = parties[0];
            position_latitude.Text = parties[1];
            position_longitude.Text = parties[2];
            minPassager.Text = parties[3];
            maxPassager.Text = parties[4];
            minCargaison.Text = parties[5];
            maxCargaison.Text = parties[6];
        }

        private void SupprimerAeroport_Click_1(object sender, EventArgs e)
        {
            if (listAeroport.SelectedItem != null)
            {
                string item = listAeroport.SelectedItem.ToString();
                string nomAeroport = item.Split('(')[0].Trim();
                DialogResult result = MessageBox.Show(
                    $"Voulez-vous vraiment supprimer l’aéroport « {nomAeroport} » ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    m_controleur.SupprimerAeroport(nomAeroport);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un aéroport à supprimer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void nouveauScenario_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Voulez-vous vraiment commencer un nouveau scénario ? Toutes les données non sauvegardées seront perdues.",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                m_controleur.CommencerNouveauScenario();
            }
        }

        private void ReinitialiserTextBox()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox textBox)
                {
                    textBox.Clear();
                }
            }
        }

        private void btnAeronef_Click(object sender, EventArgs e)
        {
            Aeroport aeroportSelectionne = listAeroport.SelectedItem as Aeroport;
            if (aeroportSelectionne == null)
            {
                MessageBox.Show("Veuillez sélectionner un aéroport valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var data = new Dictionary<string, string>()
            {
                { "Nom", nomAeronef.Text.Trim() },
                { "Type", type.Text.Trim() },
                { "Vitesse", vitesse.Text.Trim() },
                { "TempsEmbarquement", tempsEmbarquement.Text.Trim() },
                { "TempsDebarquement", tempsDebarquement.Text.Trim() },
                { "Capacite", capacite.Text.Trim() },
                { "TempsEntretien", tempsEntretien.Text.Trim() },
                { "Aeroport", aeroportSelectionne.Nom }
            };

            try
            {
                m_controleur.AjouterAeronef(data);
                MessageBox.Show("Aéronef ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Erreur de format : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangerFrequence_Click(object sender, EventArgs e)
        {
            try
            {
                m_controleur.ChangerFrequence(TypeEvenement.Observation, observations.Text);
                m_controleur.ChangerFrequence(TypeEvenement.Secours, secours.Text);
                m_controleur.ChangerFrequence(TypeEvenement.Incendie, incendies.Text);
                m_controleur.ChangerFrequence(TypeEvenement.Passager, passagers.Text);
                m_controleur.ChangerFrequence(TypeEvenement.Cargaison, cargaisons.Text);

                MessageBox.Show("Fréquences mises à jour !");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
           
