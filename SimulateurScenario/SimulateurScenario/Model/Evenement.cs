using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public class Evenement
    {
        TypeEvenement type;
        Position position;
        public int? Intensite { get; set; }
        public int? NombrePassagers { get; set; }
        public double? Vitesse { get; set; }
        Aeroport? Destination;

        public void NotifierObservateurs() { }
    }
}
