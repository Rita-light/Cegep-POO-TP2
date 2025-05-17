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
            // 1. Utilisation de GestionnaireFichierXML pour lire le fichier
            Scenario scenario = GestionnaireFichierXML.Importer(cheminFichier);

            // 2. Mise à jour du scénario actuel dans le singleton GestionnaireScenario
            m_gestionnaire.SetScenarioActuel(scenario);

            // 3. Attacher FormGenerateur comme observateur
            scenario.Attacher((IObservateur)Application.OpenForms["FormGenerateur"]);

            // 4. Notifier l'observateur
            scenario.Notifier();
        }

        public void GenererScenario() {}
        public void ExporterScenario() {}
        
        
        public void ModifierAeroport(object args) {}
        public void SupprimerAeroport(object args) {}
        
        public void AjouterAeronef(object args) {
            Aeroport aeroport = m_gestionnaire.GetScenario().GetAeroports()[0];
            if (aeroport != null)
            {
                Aeronef aeronef = new Aeronef();
                aeroport.AjouterAeronef();
            }
            else {
                // Gérer le cas où l'aéroport est null
            }
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
        
    }
}