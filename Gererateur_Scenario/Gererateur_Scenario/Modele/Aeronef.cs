using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    public abstract class Aeronef
    {
        public string Nom { get; set; }
        public double Vitesse { get; set; }
        public double TempsEntretien  { get; set; }
        public TypeAeronef type { get; set; }

        protected Aeronef(string nom, double vitesse, double tempsEntretien)
        {
            Nom = nom;
            Vitesse = vitesse;
            TempsEntretien = tempsEntretien;
        }

        public override string ToString()
        {
            return $"{Nom} - Type: {type}, Vitesse: {Vitesse}, TempsEntretien : {TempsEntretien}";
        }
        
        public virtual string Serialiser()
        {
            return $"{type}|{Nom}|{Vitesse}|{TempsEntretien}";
        }

    }
    
}
