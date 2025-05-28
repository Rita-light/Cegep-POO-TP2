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
        
        public override void Avancer(double dureeMinutes, Aeronef aeronef, Scenario scenario)
        {
            double distance = aeronef.Vitesse * (dureeMinutes / 60.0); // Vitesse en km/h * durée en heures

            aeronef.PositionActuelle = Position.CalculerNouvellePosition(
                aeronef.PositionActuelle,
                aeronef.Destination.Position,
                distance);
            Console.WriteLine($"✈️ [Vol] Avion avance. Nouvelle position : {aeronef.PositionActuelle}");

            if (EstArrive(aeronef.PositionActuelle, aeronef.Destination.Position))
            {
                aeronef.PositionActuelle = aeronef.Destination.Position;
                Console.WriteLine("✅ [Vol] Aéronef arrivé à destination. Passage à l'état Débarquement.");

                scenario.aeronefsAAjouter.Add(aeronef);
                
                if (aeronef is AeronefTransport transport)
                {
                    double tempsDebarquement = transport.CalculerTempsDebarquementTotal();
                    aeronef.ChangerEtat(TypeEtat.Debarquement, tempsDebarquementTotal : tempsDebarquement); 
                }
               
            }
        }
        
        private bool EstArrive(Position pos1, Position pos2)
        {
            return pos1.Distance(pos2) < 1.0; 
        }
    }
}
