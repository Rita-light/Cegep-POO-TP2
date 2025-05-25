using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulateurScenario.Model;

namespace SimulateurScenario
{
    public interface ISujet
    {
        void Attacher(IObservateur obs);
        void Detacher(IObservateur obs);
        void NotifierObservateur(Evenement e);
    }
}
