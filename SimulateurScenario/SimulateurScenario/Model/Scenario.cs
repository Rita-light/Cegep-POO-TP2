using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public class Scenario : ISujet
    {
        public List<Aeroport> m_aeroport { get; set; }
        public List<FrequenceEvenement> m_frequence { get; set; } =  new List<FrequenceEvenement>();
        private List<IObservateur> m_observateurs = new List<IObservateur>();
        private List<Client> clientsEvenements = new List<Client>();
        
        private static Random rnd = new Random();
        public Scenario()
        {
            m_aeroport = new List<Aeroport>();
            m_frequence = new List<FrequenceEvenement>();
            m_observateurs = new List<IObservateur>();
        }
        
        public void Attacher(IObservateur obs)
        {
            if (!m_observateurs.Contains(obs))
            {
                m_observateurs.Add(obs);
                Console.WriteLine("observateur enregistré");
            }
        }
        public void Detacher(IObservateur obs) => m_observateurs.Remove(obs);

        public void NotifierObservateur(Evenement evenement)
        {
            foreach (var obs in m_observateurs)
            {
                obs.Notifier(evenement);
            }
        }
        public void AjouterEvenementClient(Client c)
        {
            clientsEvenements.Add(c);
        }
        
        public void GenereEvenement() { }
        
//Traitement des évènements/////////////////////////////////////////////////////////////////////////////////////////////
        public Aeroport GetAeroportProche(Position coordonnees)
        {
            Aeroport aeroportProche = null;
            double distanceMin = double.MaxValue;
            
            foreach (var aeroport in m_aeroport)
            {
                double distance = aeroport.Position.Distance(coordonnees);
                if (distance < distanceMin)
                {
                    distanceMin = distance;
                    aeroportProche = aeroport;
                }
            }
            return aeroportProche;
        }

        public Aeronef TraiterEvenement(Evenement evenement)
        {
            Aeroport aeroport = GetAeroportProche(evenement.position);
            if(aeroport == null)
                return null;

            Aeronef aeronef = aeroport.GetAeronefDisponible(evenement.typeEvenement);
            if (aeronef == null)
            {
             return AutreAeroport(evenement, aeroport); ;   
            }
            
            aeroport.EnvoyerAeronef(aeronef, evenement.position);
            return aeronef;
        }

        private Aeronef AutreAeroport(Evenement evenement, Aeroport checkedAeroport)
        {
            var aeroports = m_aeroport
                .Where(a => a != checkedAeroport)
                .OrderBy(a => a.Position.Distance(evenement.position));
            
            foreach (var aeroport in aeroports)
            {
                Aeronef aeronef = aeroport.GetAeronefDisponible(evenement.typeEvenement);
                if (aeronef != null)
                {
                    aeroport.EnvoyerAeronef(aeronef, evenement.position);
                    return aeronef;
                }
            }
            return null;
        }
/// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        
        
        public List<IObservateur> GetObservateurs()
        {
            return m_observateurs;
        }
        public List<Aeroport> GetAeroports() => m_aeroport;
        
        public Aeroport GetAeroportAleatoire()
        {
            if (m_aeroport == null || m_aeroport.Count == 0)
                throw new InvalidOperationException("Aucun aéroport disponible.");

            int index = rnd.Next(m_aeroport.Count);
            return m_aeroport[index];
        }
        
        public Aeroport GetAeroportAleatoireDifferent(Aeroport aeroportExclu)
        {
            if (m_aeroport == null || m_aeroport.Count < 2)
                throw new InvalidOperationException("Pas assez d’aéroports pour choisir un différent.");

            Aeroport aeroportChoisi;
            do
            {
                aeroportChoisi = GetAeroportAleatoire();
            } while (aeroportChoisi == aeroportExclu);

            return aeroportChoisi;
        }
        
        public ScenarioMemento CreateMemento()
        {
            return new ScenarioMemento(m_aeroport);
        }

        public void RestoreMemento(ScenarioMemento memento)
        {
            m_aeroport = memento.Aeroports.Select(a => a.Clone()).ToList();
        }
        
        
    }
}
