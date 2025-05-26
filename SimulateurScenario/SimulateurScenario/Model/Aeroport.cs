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

        public void TraiterEvenement(Evenement evenement) { }
        public List<Aeronef> GetAeronefs() => Aeronefs;
        
        public void AjouterClient(Client c)
        {
            if (Clients == null) Clients = new List<Client>();
            Clients.Add(c);
        }

        public void SaveLastAeronef(Aeronef aeronef)
        {
            m_dernierAeronefEnvoye = aeronef;
        }
        
        public Aeronef GetLastAeronef() => m_dernierAeronefEnvoye;

        public List<Client> GetClients() => Clients;
        
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
