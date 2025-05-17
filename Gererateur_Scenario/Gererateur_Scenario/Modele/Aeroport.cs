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
        private List<Aeronef> Aeronefs { get; }
        private List<IObservateur> m_observateurs = new List<IObservateur>();


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

        public void Attacher(IObservateur obs)
        {
            if (!m_observateurs.Contains(obs))
            {
                m_observateurs.Add(obs);
            }
        }
        public void Detacher(IObservateur obs) => m_observateurs.Remove(obs);
        public void Notifier()
        {
            foreach (IObservateur obs in m_observateurs)
            {
                obs.MettreAJour();
            }
        }
        public void AjouterAeronef(string nom, TypeAeronef type, double vitesse, double tempsEmbarquement, double tempsDebarquement, double capacite, double tempsEntretien)
        {
            Aeronef aeronef = FabriqueAeronef.Instance.CreerAeronef(nom, type.ToString(), vitesse, tempsEmbarquement, tempsDebarquement, capacite, tempsEntretien);
            Aeronefs.Add(aeronef);
            Notifier();
        }
        public void ModifierAeronef() { }
        public void SupprimerAeronef() { }
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
