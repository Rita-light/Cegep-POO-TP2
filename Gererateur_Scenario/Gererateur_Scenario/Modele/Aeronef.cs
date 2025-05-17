using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    public class Aeronef
    {
        private string Nom;
        protected double Vitesse;
        protected double tempsEmbarquement;
        protected double tempsDembarquement;
        protected double TempsEntretien;
        public TypeAeronef type { get; set; }
        
        public Aeronef(){ }
        
        public override string ToString()
        {
            return $"{Nom} - Type: {type}, Vitesse: {Vitesse}, tempsEmbarquement: {tempsEmbarquement}, tempsDembarquement: {tempsDembarquement}, TempsEntretien : {TempsEntretien}";
        }
        
        public string Serialiser()
        {
            return $"{Nom}|{type}|{Vitesse}|{tempsEmbarquement}|{tempsDembarquement}|{TempsEntretien}";
        }

    }
    
}
