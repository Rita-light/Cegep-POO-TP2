using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulateurScenario.Model;

namespace SimulateurScenario.Modele
{
    public class Simulateur
    {
        private Scenario scenario;
        
        public Simulateur()
        {
            scenario = new Scenario();
        }
        
        public Scenario GetScenario() => scenario;
        
        public void DemarrerSimulation() { }
        public void AvancerPas() { }
        public void AvancerPlusieursPas(int nombrePas) { }
        public void GenererEvenements() { }
        public void AfficherVols() { }

        public void ChargerScenario(string nomFichier)
        {
            var nouveauScenario = GestionnaireFichierXML.Importer(nomFichier);
            
            foreach (var obs in scenario.GetObservateurs())
            {
                nouveauScenario.Attacher(obs);
            }

            scenario = nouveauScenario;
            
            // notifier la vue
            Evenement evt = new Evenement
            {
                typeEvenement = TypeEvenement.ChargementTermine,
                Aeroports = scenario.m_aeroport // on passe la liste
            };
            
            scenario.NotifierObservateur(evt);
        }
        
    }
}
