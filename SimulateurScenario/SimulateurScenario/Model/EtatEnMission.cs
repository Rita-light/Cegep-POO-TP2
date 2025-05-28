using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    class EtatEnMission : EtatAeronef
    {
        public override void AvancerPas(double pas)
        {
            Console.WriteLine($"[Mission] Aéronef en débarquement pendant {pas} pas.");
        }

        public override TypeEtat GetTypeEtat()
        {
            return TypeEtat.Debarquement;
        }
        
        public override void Avancer(double dureeMinutes, Aeronef aeronef , Scenario scenario)
        {
            // Aucun changement d'état, il attend une affectation
        }
    }
}
