using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
   public abstract class AeronefUrgence : Aeronef
    {
        
        public AeronefUrgence() : base() { }
        protected AeronefUrgence(string nom, double vitesse, double tempsEntretien, TypeEtat etat) : base(nom, vitesse, tempsEntretien, etat)
        {
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
