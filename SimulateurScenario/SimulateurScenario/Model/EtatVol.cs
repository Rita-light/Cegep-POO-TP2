using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    class EtatVol : EtatAeronef
    {
        public override TypeEtat GetTypeEtat()
        {
            return TypeEtat.Vol;
        }
        
        public override void Avancer(double dureeMinutes, Aeronef aeronef, Scenario scenario)
{
    if (aeronef.PositionDestination == null)
    {
        Console.WriteLine($"[ERREUR] {aeronef.Nom} n’a pas de position de destination definie.");
        aeronef.ChangerEtat(TypeEtat.Sol);
        return;
    }

    double distance = aeronef.Vitesse * (dureeMinutes / 60.0); // km/h * heures
    aeronef.PositionActuelle = Position.CalculerNouvellePosition(
        aeronef.PositionActuelle,
        aeronef.PositionDestination,
        distance);

    Console.WriteLine($"[Vol] {aeronef.Nom} avance. Nouvelle position : {aeronef.PositionActuelle.Latitude}, {aeronef.PositionActuelle.Longitude}");

    if (EstArrive(aeronef.PositionActuelle, aeronef.PositionDestination))
    {
        aeronef.PositionActuelle = aeronef.PositionDestination;
        Console.WriteLine($"[Vol] {aeronef.Nom} est arrive a destination");

        if (aeronef.Destination != null)
        {
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
            Console.WriteLine($"[Urgence] {aeronef.Nom} retourne a la base ({aeronef.PositionDepart.Latitude}, {aeronef.PositionDepart.Longitude})");

            aeronef.PositionDestination = aeronef.PositionDepart;
            aeronef.PositionDepart = null;

            aeronef.ChangerEtat(TypeEtat.Vol);
            scenario.aeronefsAAjouter.Add(aeronef);
        }
        else
        {
            Console.WriteLine($"[Vol] {aeronef.Nom} n’a ni Destination ni PositionDepart definie.");
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
