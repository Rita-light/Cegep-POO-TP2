using SimulateurScenario.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario
{
    public interface IObservateur
    {
        public void Notifier(Evenement evenement) { }
    }
}
