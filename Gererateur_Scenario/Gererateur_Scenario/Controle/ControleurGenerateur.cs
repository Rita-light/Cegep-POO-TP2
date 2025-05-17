using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gererateur_Scenario.Vue;


namespace Gererateur_Scenario.Controle
{
    public class ControleurGenerateur
    {
        private GestionnaireScenario m_gestionnaire;
        private FormGenerateur formGenerateur;

        public ControleurGenerateur(FormGenerateur formGenerateur)
        {
            m_gestionnaire = GestionnaireScenario.Instance;
            this.formGenerateur = formGenerateur;
        }
        
        
        public void EnregistrerObservateur(IObservateur obs)
        {
            m_gestionnaire.GetScenario().Attacher(obs);
        }

        
        public void AjouterAeroport(Dictionary<string, string> data)
        {
            string nom = data["Nom"];
            double latitude = double.Parse(data["Latitude"]);
            double longitude = double.Parse(data["Longitude"]);
            int minPassagers = int.Parse(data["MinPassagers"]);
            int maxPassagers = int.Parse(data["MaxPassagers"]);
            double minCargaisons = double.Parse(data["MinCargaisons"]);
            double maxCargaisons = double.Parse(data["MaxCargaisons"]);
            
            var position = new Position(latitude, longitude);
            var scenario = m_gestionnaire.GetScenario();
            scenario.AjouterAeroport(nom, position, minPassagers, maxPassagers, minCargaisons, maxCargaisons);
        }


        public void ChargerScenario(string cheminFichier)
        {
            // Récupérer le scénario actuel
            Scenario scenarioActuel = m_gestionnaire.GetScenario();

            // Si un scénario est déjà chargé
            if (scenarioActuel != null)
            {
                // Demander à l'utilisateur s'il souhaite enregistrer le scénario actuel
                DialogResult resultat = MessageBox.Show(
                    "Un scénario est déjà actif. Voulez-vous l'enregistrer avant de charger un nouveau scénario ?",
                    "Enregistrement du scénario",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (resultat == DialogResult.Yes)
                {
                    // Ouvrir une boîte de dialogue pour sélectionner où enregistrer le fichier
                    using (SaveFileDialog saveDialog = new SaveFileDialog())
                    {
                        saveDialog.Filter = "Fichier XML (*.xml)|*.xml";
                        saveDialog.Title = "Enregistrer le scénario";

                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            GestionnaireFichierXML.Exporter(scenarioActuel, saveDialog.FileName);
                        }
                        else
                        {
                            // Si l'utilisateur annule l'enregistrement, on arrête le chargement
                            return;
                        }
                    }
                }
                else if (resultat == DialogResult.Cancel)
                {
                    // Si l'utilisateur annule l'action, on ne fait rien
                    return;
                }
                // Si l'utilisateur clique sur No, on continue sans sauvegarder
            }

            // Charger le nouveau scénario
            Scenario nouveauScenario = GestionnaireFichierXML.Importer(cheminFichier);

            // Mettre à jour le gestionnaire avec le nouveau scénario
            m_gestionnaire.SetScenarioActuel(nouveauScenario);

            EnregistrerObservateur(formGenerateur);
            // Notifier l'observateur
            nouveauScenario.Notifier();
        }


        public void GenererScenario(String cheminFichier)
        {
            var scenario = m_gestionnaire.GetScenario();
            GestionnaireFichierXML.Exporter(scenario, cheminFichier);
        }


        public void ModifierAeroport(string ancienNom, Dictionary<string, string> data)
        {
            string nom = data["Nom"];
            double latitude = double.Parse(data["Latitude"]);
            double longitude = double.Parse(data["Longitude"]);
            int minPassagers = int.Parse(data["MinPassagers"]);
            int maxPassagers = int.Parse(data["MaxPassagers"]);
            double minCargaisons = double.Parse(data["MinCargaisons"]);
            double maxCargaisons = double.Parse(data["MaxCargaisons"]);
            
            var position = new Position(latitude, longitude);
            var scenario = m_gestionnaire.GetScenario();
            scenario.ModifierAeroport(ancienNom ,nom, position, minPassagers, maxPassagers, minCargaisons, maxCargaisons);

        }
        public void SupprimerAeroport(string nom)
        {
            var scenario = m_gestionnaire.GetScenario();
            scenario.SupprimerAeroport(nom);
        }
        
        
        public void ModifierAeroport(object args) {}
        public void SupprimerAeroport(object args) {}

        public void AjouterAeronef(Dictionary<string, string> data)
        {
            string[] champs = {"Nom", "Type", "Aeroport", "Vitesse", "TempsEmbarquement", "TempsDebarquement", "Capacite", "TempsEntretien"};

            foreach (var champ in champs)
            {
                if (!data.TryGetValue(champ, out string valeur) || string.IsNullOrWhiteSpace(valeur))
                {
                    MessageBox.Show($"Le champ '{champ}' est requis et ne peut pas être vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            string nom = data["Nom"];
            string typeStr = data["Type"];
            string aeroportStr = data["Aeroport"];

            if (!Enum.TryParse(typeStr, true, out TypeAeronef type))
            {
                throw new ArgumentException($"Type d’aéronef invalide : {typeStr}");
            }

            if (!double.TryParse(data["Vitesse"], out double vitesse))
                throw new ArgumentException("La vitesse doit être un nombre valide.");

            if (!double.TryParse(data["TempsEmbarquement"], out double tempsEmbarquement))
                throw new ArgumentException("Le temps d'embarquement doit être un nombre valide.");

            if (!double.TryParse(data["TempsDebarquement"], out double tempsDebarquement))
                throw new ArgumentException("Le temps de débarquement doit être un nombre valide.");

            if (!double.TryParse(data["Capacite"], out double capacite))
                throw new ArgumentException("La capacité doit être un nombre valide.");

            if (!double.TryParse(data["TempsEntretien"], out double tempsEntretien))
                throw new ArgumentException("Le temps d'entretien doit être un nombre valide.");

            Aeroport aeroport = ObtenirAeroportSelectionne(aeroportStr);
            if (aeroport == null)
            {
                throw new ArgumentException($"Aéroport '{aeroportStr}' introuvable.");
            }

            aeroport.AjouterAeronef(
                nom,
                type,
                vitesse,
                tempsEmbarquement,
                tempsDebarquement,
                capacite,
                tempsEntretien
            );
        }
        public void CommencerNouveauScenario()
        {
            m_gestionnaire.NouveauScenario();
            EnregistrerObservateur(formGenerateur);
            m_gestionnaire.GetScenario().Notifier(); 
        }     

        public void ModifierAeronef(object args) {}
        public void SupprimerAeronef(object args) {}
        
        public void AjouterEvenement(object args) {}
        public void ModifierEvenement(object args) {}
        public void SupprimerEvenement(object args) {}
        
        public void ChangerFrequence(object args) {}
        
        public List<string> ObtenirListeAeroports()
        {
            return m_gestionnaire.ObtenirListeAeroports();
        }
        
        public List<string> ObtenirListeAeronefs(string nomAeroport)
        {
            return m_gestionnaire.ObtenirListeAeronefs(nomAeroport);
        }

        public Aeroport ObtenirAeroportSelectionne(string nomAeroport)
        {
            if (string.IsNullOrWhiteSpace(nomAeroport))
                return null;

            return m_gestionnaire.ObtenirAeroportSelectionne(nomAeroport);
        }
    }
}