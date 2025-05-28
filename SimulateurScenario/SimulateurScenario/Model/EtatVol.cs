using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    class EtatVol : EtatAeronef
    {
        public override void AvancerPas(double pas)
        {
            Console.WriteLine($"[Vol] Aéronef en vol pendant {pas} pas.");
        }

        public override TypeEtat GetTypeEtat()
        {
            return TypeEtat.Vol;
        }
        
        public override void Avancer(double dureeMinutes, Aeronef aeronef)
        {
            double distance = aeronef.Vitesse * (dureeMinutes / 60.0); // Vitesse en km/h * durée en heures

            aeronef.PositionActuelle = Position.CalculerNouvellePosition(
                aeronef.PositionActuelle,
                aeronef.PositionDestination,
                distance);

            if (EstArrive(aeronef.PositionActuelle, aeronef.PositionDestination))
            {
                aeronef.PositionActuelle = aeronef.PositionDestination;
                aeronef.ChangerEtat(TypeEtat.Debarquement); 
            }
            
            
        }
        
        private bool EstArrive(Position pos1, Position pos2)
        {
            return pos1.Distance(pos2) < 1.0; 
        }
    }
}
