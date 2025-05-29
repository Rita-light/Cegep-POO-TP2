using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public abstract class EtatAeronef
    {
        public abstract void Avancer(double duree, Aeronef aeronef,  Scenario scenario);
        public abstract TypeEtat GetTypeEtat();
        public void GererEtat(Aeronef aeronef) { }        
    }
}
