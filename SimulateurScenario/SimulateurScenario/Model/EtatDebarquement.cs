using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    class EtatDebarquement : EtatAeronef
    {
        private double tempsRestant;
        
        public EtatDebarquement(double dureeDebarquement)
        {
            tempsRestant = dureeDebarquement;
        }
        

        public override TypeEtat GetTypeEtat()
        {
            return TypeEtat.Embarquement;
        }
        
        public override void Avancer(double dureeMinutes, Aeronef aeronef , Scenario scenario)
        {
            tempsRestant -= dureeMinutes;
            Console.WriteLine($"[Debarquemment] : tems restant de {tempsRestant} minutes.");
            
            if (tempsRestant <= 0)
            {
                aeronef.ChangerEtat(TypeEtat.Entretien);
            }
        }
    }
}
