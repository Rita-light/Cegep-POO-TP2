using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public class Aeroport
    {
        private Aeronef m_dernierAeronefEnvoye;
        public string Nom { get; set; }
        public Position Position { get; set; }
        public int MinPassagers { get; set; }
        public int MaxPassagers { get; set; }
        public double MinCargaisons { get; set; }
        public double MaxCargaisons { get; set; }
        public List<Aeronef> Aeronefs { get; set; }
        public List<Client> Clients { get; set; }
        
        

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
            Clients = new List<Client>();
        }
        public Aeronef GetAeronefDisponible(TypeEvenement typeEvenement)
        {
            return Aeronefs.FirstOrDefault(a => a.EtatActuel.GetTypeEtat() == TypeEtat.Sol &&
                                                (typeEvenement switch
                                                {
                                                    TypeEvenement.Incendie => a is AvionCiterne,
                                                    TypeEvenement.Observation => a is Helicoptere,
                                                    TypeEvenement.Secours => a is AvionSecours,
                                                    _ => false
                                                }));
        }

        public void EnvoyerAeronefUrgence(Aeronef aeronef, Position positionEvenement)
        {
            if (aeronef == null || positionEvenement == null)
                throw new ArgumentNullException("Aéronef ou destination invalide pour la mission d'urgence.");
            aeronef.PositionActuelle = this.Position;
            aeronef.PositionDepart = this.Position;
            
            aeronef.PositionDestination = positionEvenement;
            aeronef.Destination = null; // Pas d'aéroport comme destination
            
            aeronef.ChangerEtat(TypeEtat.Vol);
            
            Console.WriteLine($"[Urgence] {aeronef.Nom} envoyé en mission vers {positionEvenement} depuis {this.Nom}");
        }
        
        
        public List<Aeronef> GetAeronefs() => Aeronefs;
        
        public void AjouterClient(Client c)
        {
            if (Clients == null) Clients = new List<Client>();
            Clients.Add(c);
        }
        

        
        
        public List<Client> GetClients() => Clients;
        
        public double GetPoidsActuel()
        {
            double poidsTotal = 0;

            foreach (Client client in Clients)
            {
                if (client is Cargo cargo)
                {
                    poidsTotal += cargo.PoidsCargaison;
                }
            }

            return poidsTotal;
        }
        
        public void AjouterAeronef(Aeronef a)
        {
            Aeronefs.Add(a);
        }

        public void RetirerAeronef(Aeronef a)
        {
            Aeronefs.Remove(a);
        }

        
        public Aeroport Clone()
        {
            return new Aeroport
            {
                Nom = this.Nom,
                Position = this.Position.Clone(),
                MinPassagers = this.MinPassagers,
                MaxPassagers = this.MaxPassagers,
                MinCargaisons = this.MinCargaisons,
                MaxCargaisons = this.MaxCargaisons,
                Clients = this.Clients.Select(c => c.Clone()).ToList(),
                //Aeronefs = this.Aeronefs.Select(a => a.Clone()).ToList()
                Aeronefs = new List<Aeronef>(this.Aeronefs)
            };
        }

    }
}
