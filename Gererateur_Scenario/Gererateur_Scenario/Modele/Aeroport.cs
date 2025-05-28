using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    public class Aeroport
    {
        public string Nom { get; set; }
        public Position Position { get; set; }
        public int MinPassagers { get; set; }
        public int MaxPassagers { get; set; }
        public double MinCargaisons { get; set; }
        public double MaxCargaisons { get; set; }
        public List<Aeronef> Aeronefs { get; set; }

       public Aeroport() 
       {
       }
        public Aeroport(string nom, Position position, int minPassagers, int maxPassagers, double minCargaisons, double maxCargaisons)
        {
            Nom = nom;
            Position = position;
            MinPassagers = minPassagers;
            MaxPassagers = maxPassagers;
            MinCargaisons = minCargaisons;
            MaxCargaisons = maxCargaisons;
            Aeronefs = new List<Aeronef>();
        }

        public void AjouterAeronef(string nom, TypeAeronef type, double vitesse, double tempsEmbarquement, double tempsDebarquement, double capacite, double tempsEntretien, TypeEtat etat)
        {
            Aeronef aeronef = FabriqueAeronef.Instance.CreerAeronef(nom, type, vitesse, tempsEmbarquement, tempsDebarquement, capacite, tempsEntretien, etat);
            Aeronefs.Add(aeronef);
        }
        /*public void ModifierAeronef(string ancienNom, string nouveauNom, TypeAeronef type, double vitesse, double tempsEmbarquement, double tempsDebarquement, double capacite, double tempsEntretien)
        {
            var aeronef = Aeronefs.FirstOrDefault(a => a.Nom.Equals(ancienNom, StringComparison.OrdinalIgnoreCase));
            if (aeronef == null)
                throw new ArgumentException("Aéronef non trouvé : " + ancienNom);

            aeronef.Nom = nouveauNom;
            aeronef.Vitesse = vitesse;
            aeronef.TempsEntretien = tempsEntretien;

            switch (type)
            {
                case TypeAeronef.Passager:
                    if (aeronef is AvionPassager avionPassager)
                    {
                        avionPassager.TempsEmbarquement = tempsEmbarquement;
                        avionPassager.TempsDebarquement = tempsDebarquement;
                        avionPassager.Capacite = (int)capacite;
                    }
                    break;
                case TypeAeronef.Cargo:
                    if (aeronef is AvionCargaison avionCargaison)
                    {
                        avionCargaison.TempsEmbarquement = tempsEmbarquement;
                        avionCargaison.TempsDebarquement = tempsDebarquement;
                        avionCargaison.Capacite = capacite;
                    }
                    break;
                case TypeAeronef.Secours:
                    break;
                case TypeAeronef.Citerne:
                    break;
                case TypeAeronef.Helicoptere:
                    break;
                default:
                    throw new ArgumentException("Type d'aéronef inconnu");
            }
        }*/

        public void SupprimerAeronef(String nomAeronef) { 
            var aeronef = Aeronefs.FirstOrDefault(a => a.Nom.Equals(nomAeronef, StringComparison.OrdinalIgnoreCase));
            if (aeronef != null)
            {
                Aeronefs.Remove(aeronef);
            }        
        }

        public List<Aeronef> GetAeronefs() => Aeronefs;
        
        public override string ToString()
        {
            return $"{Nom} ({Position.ToString()}), minPassagers: {MinPassagers}, maxPassagers: {MaxPassagers}, minCargaison: {MinCargaisons}, maxCargaison : {MaxCargaisons}";
        }
        public string Serialiser()
        {
            return $"{Nom}|{Position.ToString()}|{MinPassagers}|{MaxPassagers}|{MinCargaisons}|{MaxCargaisons}";
        }
        
        public List<string> ObtenirListeAeronefs()
        {
            
            List<string> liste = new List<string>();

            foreach (var aeronef in Aeronefs)
            {
                liste.Add(aeronef.Serialiser());
            }
            return liste;
        }

    }
}
