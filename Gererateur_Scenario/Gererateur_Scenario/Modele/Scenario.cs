using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    public class Scenario
    {
        public List<Aeroport> aeroports { get; set; }
        public List<Evenement> evenements { get; set; }
        private List<IObservateur> m_observateurs = new List<IObservateur>();


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
        public void Notifier()
        {
            foreach (IObservateur obs in m_observateurs)
            {
                obs.MettreAJour();
            }
        }
        
        public List<string> ObtenirListeAeroports()
        {
            List<string> liste = new List<string>();

            foreach (var aeroport in aeroports)
            {
                liste.Add(aeroport.Serialiser());
            }

            return liste;
        }
        
        public List<string> ObtenirListeAeronefs(string nomAeroport)
        {
            foreach (var aeroport in aeroports)
            {
                if (aeroport.Nom == nomAeroport)
                {
                    return aeroport.ObtenirListeAeronefs();
                }
            }

            return new List<string>();
        }


    }
}
