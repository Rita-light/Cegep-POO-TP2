using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    public class Helicoptere : Aeronef
    {
        public Helicoptere() : base() { }
        public Helicoptere(string nom, double vitesse, double tempsEntretien) : base(nom, vitesse, tempsEntretien)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Type: Helicoptere";
        }

        public override string Serialiser()
        {
            return $"{base.Serialiser()}|Helicoptere";
        }
    }
}
