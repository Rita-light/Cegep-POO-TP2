using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    class GestionnaireScenario
    {
        private static GestionnaireScenario _instance;
        private static readonly object _lock = new object();
        private Scenario scenarioActuel ;

        private GestionnaireScenario() { }
        public static GestionnaireScenario Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new GestionnaireScenario();
                    }
                    return _instance;
                }
            }
        }
        public Scenario GetScenarioActuel() =>scenarioActuel;
        
        public void SetScenarioActuel(Scenario scenario)
        {
            scenarioActuel = scenario;
        }
        
        public void NouveauScenario()
        {
            scenarioActuel = new Scenario();
        }
        
        public List<string> ObtenirListeAeroports()
        {
            return scenarioActuel.ObtenirListeAeroports();
        }
        
        public List<string> ObtenirListeAeronefs(string nomAeroport)
        {
            return scenarioActuel.ObtenirListeAeronefs(nomAeroport);
        }


    }
}
