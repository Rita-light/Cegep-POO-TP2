using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    public class Aeroport
    {
        public string Nom { get; set; }
        public Position Position { get; set; }
        public int MinPassagers { get; set; }
        public int MaxPassagers { get; set; }
        public double MinCargaisons { get; set; }
        public double MaxCargaisons { get; set; }
        private List<Aeronef> Aeronefs { get; } 
        
        public Aeroport() 
        {
        }
        public Aeroport(string nom, Position position, int minPassagers, int maxPassagers, double minCargaisons, double maxCargaisons)
        {
            Nom = nom;
            Position = position;
            MinPassagers = minPassagers;
            MaxPassagers = maxPassagers;
            MinCargaisons = minCargaisons;
            MaxCargaisons = maxCargaisons;
            Aeronefs = new List<Aeronef>();
        }

        public void AjouterAeronef() { }
        public void ModifierAeronef() { }
        public void SupprimerAeronef() { }
        public List<Aeronef> GetAeronefs() => Aeronefs;
        
        public override string ToString()
        {
            return $"{Nom} ({Position.ToString()}), minPassagers: {MinPassagers}, maxPassagers: {MaxPassagers}, minCargaison: {MinCargaisons}, maxCargaison : {MaxCargaisons}";
        }
        public string Serialiser()
        {
            return $"{Nom}|{Position.ToString()}|{MinPassagers}|{MaxPassagers}|{MinCargaisons}|{MaxCargaisons}";
        }
        
        public List<string> ObtenirListeAeronefs()
        {
            
            List<string> liste = new List<string>();

            foreach (var aeronef in Aeronefs)
            {
                liste.Add(aeronef.Serialiser());
            }
            return liste;
        }

    }
}
