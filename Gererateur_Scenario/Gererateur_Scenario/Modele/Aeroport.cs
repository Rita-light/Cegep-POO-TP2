using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    public abstract class Aeroport
    {
        public string Nom { get; set; }
        public (int, int) Position { get; set; }
        public int MinPassagers { get; set; }
        public int MaxPassagers { get; set; }
        public double MinCargaisons { get; set; }
        public double MaxCargaisons { get; set; }
        private List<Aeronef> Aeronefs { get; } 

        public void AjouterAeronef() { }
        public void ModifierAeronef() { }
        public void SupprimerAeronef() { }
        public List<Aeronef> GetAeronefs() => Aeronefs;
    }
}
