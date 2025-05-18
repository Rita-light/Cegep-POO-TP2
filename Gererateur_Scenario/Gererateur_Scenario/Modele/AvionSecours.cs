using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    public class AvionSecours : AeronefUrgence
    {
        public AvionSecours(string nom, double vitesse, double tempsEntretien) : base(nom, vitesse, tempsEntretien)
        {
        }

        public override string ToString()
        {
            return $"{Nom} - Type: {type}, Vitesse: {Vitesse}, TempsEntretien : {TempsEntretien}";
        }

        public override string Serialiser()
        {
            return $"{type}|{Nom}|{Vitesse}|{TempsEntretien}";
        }
    }
}
