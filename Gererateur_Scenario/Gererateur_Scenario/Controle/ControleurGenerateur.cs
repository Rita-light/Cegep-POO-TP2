using System.Collections.Generic;


namespace Gererateur_Scenario.Controle
{
    public class ControleurGenerateur
    {
        private GestionnaireScenario m_gestionnaire;

        public void ChargerScenario() {}
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
        
        public List<Aeroport> GetAeroports() => null;
        public List<Evenement> GetEvenements() => null;
        
        public void EnregistrerObservateur(IObservateur obs) {}
    }
}