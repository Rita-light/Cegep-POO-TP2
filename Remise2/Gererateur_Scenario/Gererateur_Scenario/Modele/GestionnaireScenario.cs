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
        private Scenario m_scenario  ;

        private GestionnaireScenario()
        {
            m_scenario = new Scenario();
        }
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
        public Scenario GetScenario() => m_scenario;

        public void SetScenarioActuel(Scenario scenario)
        {
            m_scenario = scenario;
        }

        public void NouveauScenario()
        {
            m_scenario = new Scenario();
        }

        public List<string> ObtenirListeAeroports()
        {
            return m_scenario.ObtenirListeAeroports();
        }

        public List<string> ObtenirListeAeronefs(string nomAeroport)
        {
            return m_scenario.ObtenirListeAeronefs(nomAeroport);
        }
                     
    }
}
