using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    public abstract class AeronefTransport : Aeronef
    {
        public double TempsEmbarquement { get; set; }
        public double TempsDebarquement { get; set; }

        protected AeronefTransport(string nom, double vitesse, double tempsEntretien, double tempsEmbarquement, double tempsDebarquement)
            : base(nom, vitesse, tempsEntretien)
        {
            TempsEmbarquement = tempsEmbarquement;
            TempsDebarquement = tempsDebarquement;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, TempsEmbarquement: {TempsEmbarquement}, TempsDebarquement: {TempsDebarquement}";
        }

        public override string Serialiser()
        {
            return $"{base.Serialiser()}|{TempsEmbarquement}|{TempsDebarquement}";
        }
    }
}
