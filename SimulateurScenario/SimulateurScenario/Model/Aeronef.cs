using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimulateurScenario.Model
{

    [XmlInclude(typeof(AeronefTransport))]
    [XmlInclude(typeof(AvionPassager))]
    [XmlInclude(typeof(AvionCargaison))]
    [XmlInclude(typeof(AeronefUrgence))]
    [XmlInclude(typeof(Helicoptere))]
    [XmlInclude(typeof(AvionSecours))]
    [XmlInclude(typeof(AvionCiterne))]
    public abstract class Aeronef
    {
        public string Nom { get; set; }
        public double Vitesse { get; set; }
        public double TempsEntretien { get; set; }
        public TypeAeronef type { get; set; }
        public TypeEtat typeEtat { get; set; }
        public Position PositionActuelle { get; set; }
        public Position PositionDepart { get; set; }
        public Aeroport Destination { get; set; }
        public Position  PositionDestination{ get; set; }
        
        public Aeroport AeroportDepart { get; set; }
        
        public EtatAeronef EtatActuel { get; set; }

        public Aeronef() {}

        protected Aeronef(string nom, double vitesse, double tempsEntretien, TypeEtat etat)
        {
            Nom = nom;
            Vitesse = vitesse;
            TempsEntretien = tempsEntretien;
            typeEtat = etat;
        }
        
        public EtatAeronef CreerEtatDepuisType(TypeEtat type, double? tempsEmbarquementTotal = null, double? tempsDebarquementTotal = null)
        {
            typeEtat = type;
            return type switch
            {
                TypeEtat.Entretien => new EtatEntretien(TempsEntretien),
                TypeEtat.Vol => new EtatVol(),
                TypeEtat.Sol => new EtatSol(),
                TypeEtat.Embarquement => tempsEmbarquementTotal.HasValue
                    ? new EtatEmbarquement(tempsEmbarquementTotal.Value)
                    : throw new ArgumentException("Le temps d'embarquement est requis pour l'état Embarquement."),

                TypeEtat.Debarquement => tempsDebarquementTotal.HasValue
                    ? new EtatDebarquement(tempsDebarquementTotal.Value)
                    : throw new ArgumentException("Le temps de débarquement est requis pour l'état Débarquement."),

                _ => throw new ArgumentException("Type d'état inconnu", nameof(type))
            };
        }

        

        public void Avancer(Position destination)
        {
            PositionActuelle = destination;
            typeEtat = TypeEtat.Vol;
            EtatActuel = CreerEtatDepuisType(typeEtat);
        }

        public void MettreAJourPosition(double ratio)
        {
            double nouvelleLatitude = PositionActuelle.Latitude + (PositionDestination.Latitude - PositionActuelle.Latitude) * ratio;
            double nouvelleLongitude = PositionActuelle.Longitude + (PositionDestination.Longitude - PositionActuelle.Longitude) * ratio;
            PositionActuelle = new Position(nouvelleLatitude, nouvelleLongitude);
        }
        
        public void ChangerEtat(TypeEtat nouvelEtat, double? tempsEmbarquementTotal = null, double? tempsDebarquementTotal = null)
        {
            // Met à jour l'état en passant correctement les paramètres
            EtatActuel = CreerEtatDepuisType( nouvelEtat, tempsEmbarquementTotal, tempsDebarquementTotal);
        }
        


        public override string ToString()
        {
            return $"{Nom} - Type: {type}, Vitesse: {Vitesse}, TempsEntretien : {TempsEntretien}";
        }

        public virtual string Serialiser()
        {
            return $"{type}|{Nom}|{Vitesse}|{TempsEntretien}";
        }
        
        
    }
}
