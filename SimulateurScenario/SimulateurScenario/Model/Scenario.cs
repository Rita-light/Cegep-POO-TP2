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
        
        public void GenereEvenement() { }
        public void TraiterEvenement(Evenement evenement) { }

        public Aeroport GetAeroportProche(Position coordonnees)
        {
            return m_aeroport.FirstOrDefault(o => o.Position == coordonnees);
        }
        
        public List<IObservateur> GetObservateurs()
        {
            return m_observateurs;
        }


       

        
    }
}
