using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    class Passager : ClientTransport
    {
        public int NbPassagers { get; set; }
        Aeroport Destination;
    }
}
