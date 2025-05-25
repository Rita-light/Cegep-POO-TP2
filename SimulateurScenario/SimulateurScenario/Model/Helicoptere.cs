using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public class Helicoptere : AeronefUrgence
    {
        public Helicoptere() : base() { }
        public Helicoptere(string nom, double vitesse, double tempsEntretien, TypeEtat etat) : base(nom, vitesse, tempsEntretien, etat)
        {
            type = TypeAeronef.Helicoptere;
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Type: Helicoptere";
        }

        public override string Serialiser()
        {
            return $"{base.Serialiser()}";
        }
    }
}
