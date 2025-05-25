using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public class AvionSecours : AeronefUrgence
    {
        public AvionSecours() : base() { }
        public AvionSecours(string nom, double vitesse, double tempsEntretien) : base(nom, vitesse, tempsEntretien)
        {
            type = TypeAeronef.Secours;
        }

        public override string ToString()
        {
            return $"{Nom} - Type: {type}, Vitesse: {Vitesse}, TempsEntretien : {TempsEntretien}";
        }

        public override string Serialiser()
        {
            return $"{base.Serialiser()}";
        }
    }
}
