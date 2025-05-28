using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    class EtatEmbarquement : EtatAeronef
    {
        private double tempsRestant;
        public EtatEmbarquement(double dureeEmbarquement)
        {
            tempsRestant = dureeEmbarquement;
        }
        public override void AvancerPas(double pas)
        {
            Console.WriteLine($"[Ebarquement] Aéronef en débarquement pendant {pas} pas.");
        }

        public override TypeEtat GetTypeEtat()
        {
            return TypeEtat.Embarquement;
        }
        
        public override void Avancer(double dureeMinutes, Aeronef aeronef)
        {
            tempsRestant -= dureeMinutes;
            if (tempsRestant <= 0)
            {
                aeronef.ChangerEtat(TypeEtat.Vol); // état suivant logique
            }
        }
    }
}
