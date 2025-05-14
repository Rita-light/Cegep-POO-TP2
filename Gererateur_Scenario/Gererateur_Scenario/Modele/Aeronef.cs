using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    public class Aeronef
    {
        protected string Nom;
        protected double Vitesse;
        protected double TempsEntretien;

        public TypeAeronef type { get; set; }
    }
}
