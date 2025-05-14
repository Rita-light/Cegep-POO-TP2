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
        private Scenario m_scenario;

        //public static GestionnaireScenario Instance => _instance ??= new GestionnaireScenario();
        public Scenario GetScenarioActuel() => m_scenario;
        public void NouveauScenario() {}
    }
}
