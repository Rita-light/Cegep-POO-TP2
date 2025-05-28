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
    // ✅ Vérification de la destination avant tout
    if (aeronef.PositionDestination == null)
    {
        Console.WriteLine($"❌ [ERREUR] {aeronef.Nom} n’a pas de position de destination définie.");
        aeronef.ChangerEtat(TypeEtat.Sol);
        return;
    }

    // 🚀 Calcul du déplacement
    double distance = aeronef.Vitesse * (dureeMinutes / 60.0); // km/h * heures
    aeronef.PositionActuelle = Position.CalculerNouvellePosition(
        aeronef.PositionActuelle,
        aeronef.PositionDestination,
        distance);

    Console.WriteLine($"[Vol] {aeronef.Nom} avance. Nouvelle position : {aeronef.PositionActuelle}");

    // 🎯 Vérification d’arrivée
    if (EstArrive(aeronef.PositionActuelle, aeronef.PositionDestination))
    {
        aeronef.PositionActuelle = aeronef.PositionDestination;
        Console.WriteLine($"✅ [Vol] {aeronef.Nom} est arrivé à destination.");

        if (aeronef.Destination != null)
        {
            // ✈️ C’est un vol planifié (passager ou cargo)
            scenario.aeronefsAAjouter.Add(aeronef);

            if (aeronef is AeronefTransport transport)
            {
                double tempsDebarquement = transport.CalculerTempsDebarquementTotal();
                aeronef.ChangerEtat(TypeEtat.Debarquement, tempsDebarquementTotal: tempsDebarquement);
            }
            else
            {
                aeronef.ChangerEtat(TypeEtat.Sol);
            }
        }
        else if (aeronef.PositionDepart != null)
        {
            // 🚨 Vol d’urgence : retour à la base
            Console.WriteLine($"[Urgence] {aeronef.Nom} retourne a la base ({aeronef.PositionDepart})");

            aeronef.PositionDestination = aeronef.PositionDepart;
            aeronef.Destination = scenario.GetAeroportProche(aeronef.PositionDepart);
            aeronef.PositionDepart = null;

            aeronef.ChangerEtat(TypeEtat.Vol);
            scenario.aeronefsAAjouter.Add(aeronef);
        }
        else
        {
            // 🟡 Aéronef sans destination claire : atterrissage d’urgence
            Console.WriteLine($"⚠️ [Vol] {aeronef.Nom} n’a ni Destination ni PositionDepart définie.");
            aeronef.ChangerEtat(TypeEtat.Sol);
        }
    }
}

        
        private bool EstArrive(Position pos1, Position pos2)
        {
            return pos1.Distance(pos2) < 1.0; 
        }
    }
}
