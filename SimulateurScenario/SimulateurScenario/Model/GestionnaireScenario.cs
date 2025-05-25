using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public class GestionnaireScenario
    {
        private static GestionnaireScenario _instance;
        private static readonly object _lock = new object();
        private Scenario m_scenario;

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
        public void ChargerScenario(string nomFichier)
        {
            m_scenario.ChargerScenario(nomFichier);
        }
    }
}
