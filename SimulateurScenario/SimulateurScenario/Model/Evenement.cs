using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public class Evenement
    {
        public TypeEvenement typeEvenement { get; set; }
        public Position position {get;set;}
        public int? Intensite { get; set; }
        public int? NombrePassagers { get; set; }
        public double? PoidsCargo { get; set; }  
        public double? Vitesse { get; set; }
        public Aeroport? Destination;
        public List<Aeroport>? Aeroports { get; set; }
        public List<Aeronef>? Aeronefs {get;set;}

        public void NotifierObservateurs() { }
    }
}
