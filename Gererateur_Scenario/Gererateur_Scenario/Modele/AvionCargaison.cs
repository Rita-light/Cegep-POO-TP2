using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    public class AvionCargaison : AeronefTransport
    {
        public double Capacite { get; set; }

        public AvionCargaison() : base(){ }

        public AvionCargaison(string nom, double vitesse, double tempsEntretien, double capacite, double tempsEmbarquement, double tempsDebarquement, TypeEtat etat)
            : base(nom, vitesse, tempsEntretien, tempsEmbarquement, tempsDebarquement,etat)
        {
            Capacite = capacite;
            type = TypeAeronef.Cargo;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Capacite: {Capacite}";
        }

        public override string Serialiser()
        {
            return $"{base.Serialiser()}|{Capacite}";
        }
    }
}
