using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public class  Cargo :ClientTransport
    {
        public double PoidsCargaison { get; set; }
        Aeroport Destination;
    }
}
