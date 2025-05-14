using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    public abstract class AeronefTransport : Aeronef
    {
        public double Capacite { get; set; }
        public double TempsEmbarquement { get; set; }
        public double TempsDebarquement { get; set; }
    }

}
