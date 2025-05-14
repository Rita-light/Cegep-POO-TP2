using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    public class Scenario
    {
        private List<Aeroport> aeroports;
        private List<Evenement> evenements;
        private List<IObservateur> m_observateurs ;
        
        
        public List<Aeroport> Aeroports
        {
            get { return aeroports; }
            set { aeroports = value; }
        }

        public List<Evenement> Evenements
        {
            get { return evenements; }
            set { evenements = value; }
        }
        
        public Scenario()
        {
            aeroports = new List<Aeroport>();
            evenements = new List<Evenement>();
        }

        public void AjouterAeroport(Aeroport aeroport)
        {
            aeroports.Add(aeroport);
        }
        public void SupprimerAeroport(Aeroport aeroport)
        {
            aeroports.Remove(aeroport);
        }
        public void ModifierAeroport(Aeroport aeroport)
        {
        }
        public void AjouterEvenement(Evenement evenement)
        {
            evenements.Add(evenement);
        }
        public void SupprimerEvenement(Evenement evenement)
        {
            evenements.Remove(evenement);
        }
        public void ModifierEvenement(Evenement evenement)
        {
        }
        public List<Aeroport> GetAeroports()
        {
            return aeroports;
        }
        public List<Evenement> GetEvenements()
        {
            return evenements;
        }
        /*public void ImporterScenario(string cheminFichier)
        {
        }
        public void ExporterScenario(string cheminFichier)
        {
        }*/
        
        public void Attacher(IObservateur obs) => m_observateurs.Add(obs);
        public void Detacher(IObservateur obs) => m_observateurs.Remove(obs);
        public void Notifier() {}



    }
}
