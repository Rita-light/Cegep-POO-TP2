using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    class EtatEntretien : EtatAeronef
    {
        private double tempsRestant;
        
        public EtatEntretien(double tempsEntretien)
        {
            tempsRestant = tempsEntretien;
        }
        public override void AvancerPas(double pas)
        {
            Console.WriteLine($"[Entretien] Aéronef en entretien pendant {pas} pas.");
        }

        public override TypeEtat GetTypeEtat()
        {
            return TypeEtat.Entretien;
        }
        
        public override void Avancer(double dureeMinutes, Aeronef aeronef , Scenario scenario)
        {
            tempsRestant -= dureeMinutes;
            Console.WriteLine($"[Entretien] Aéronef en entretien pendant {tempsRestant} minutes");
            if (tempsRestant <= 0)
            {
                aeronef.ChangerEtat(TypeEtat.Sol); 
                Console.WriteLine($"[Disponible] Aéronef disponible");
            }
        }
        
    }
}
