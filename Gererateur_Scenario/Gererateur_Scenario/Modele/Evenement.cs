using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    public class Evenement
    {
        public TypeEvenement Type { get; set; }
        public int FrequenceParHeure { get; set; }
        private Queue<double> HeuresPrevision ;
        //private StrategieHoraire Strategie;

        public bool EstPrevu(double temps) => false;
    }
}
