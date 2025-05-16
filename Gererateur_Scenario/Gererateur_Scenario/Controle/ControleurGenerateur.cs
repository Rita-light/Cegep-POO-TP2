using System.Collections.Generic;
using System.Windows.Forms;


namespace Gererateur_Scenario.Controle
{
    public class ControleurGenerateur
    {
        private GestionnaireScenario m_gestionnaire;

        public void ChargerScenario(string cheminFichier)
        {
            // 1. Utilisation de GestionnaireFichierXML pour lire le fichier
            Scenario scenario = GestionnaireFichierXML.Importer(cheminFichier);

            // 2. Mise à jour du scénario actuel dans le singleton GestionnaireScenario
            GestionnaireScenario.Instance.SetScenarioActuel(scenario);

            // 3. Attacher FormGenerateur comme observateur
            scenario.Attacher((IObservateur)Application.OpenForms["FormGenerateur"]);

            // 4. Notifier l'observateur
            scenario.Notifier();
        }

        public void GenererScenario() {}
        public void ExporterScenario() {}
        
        public void AjouterAeroport(object args) {
        
        }
        public void ModifierAeroport(object args) {}
        public void SupprimerAeroport(object args) {}
        
        public void AjouterAeronef(object args) {
            Aeroport aeroport = GestionnaireScenario.Instance.GetScenarioActuel().GetAeroports()[0];
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


        public void EnregistrerObservateur(IObservateur obs) {}
    }
}