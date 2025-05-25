using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public class Scenario
    {
        public List<Aeroport> m_aeroport { get; set; }
        public List<Frequence> m_frequence { get; set; }
        private List<IObservateur> m_observateurs = new List<IObservateur>();

        public Scenario()
        {
            m_aeroport = new List<Aeroport>();
            m_frequence = new List<Frequence>();
            m_observateurs = new List<IObservateur>();
        }

        public void AjouterObservateur(IObservateur observateur) { }    
        public void GenereEvenement() { }
        public void TraiterEvenement(Evenement evenement) { }
        public Aeroport GetAeroportProche(Position coordonnees) { }
    }
}
