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
        public List<FrequenceEvenement> frequenceEvenements { get; set; } = new List<FrequenceEvenement>();
        private List<IObservateur> m_observateurs = new List<IObservateur>();

<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        public Scenario()
        {
            aeroports = new List<Aeroport>();
            frequenceEvenements = new List<FrequenceEvenement>();
            m_observateurs = new List<IObservateur>();
        }
        
        public void AjouterAeroport(Aeroport aeroport)
        {
            aeroports.Add(aeroport);
        }
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        public void SupprimerAeroport(Aeroport aeroport)
        {
            aeroports.Remove(aeroport);
        }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        
        public List<Aeroport> GetAeroports()
        {
            return aeroports;
        }
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        public void ModifierAeroport(Aeroport aeroport)
        {
        }
        
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        /*public void ImporterScenario(string cheminFichier)
        {
        }
        public void ExporterScenario(string cheminFichier)
        {
        }*/

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
        
        public void AjouterAeroport(string nom, Position position, int minPassagers, int maxPassagers, double minCargaisons, double maxCargaisons)
        {
            var aeroport = new Aeroport(nom, position, minPassagers, maxPassagers, minCargaisons, maxCargaisons);
            aeroports.Add(aeroport);
            Notifier();
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
        public Aeroport ObtenirAeroportSelectionne(string nomAeroport)
        {
            if (string.IsNullOrEmpty(nomAeroport))
            {
                return null;
            }
            return aeroports.FirstOrDefault(a => a.Nom.Equals(nomAeroport, StringComparison.OrdinalIgnoreCase));
        }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
        public void ModifierAeroport(string ancienNom, string nouveauNom, Position position, int minPassagers, int maxPassagers, double minCargaisons, double maxCargaisons)
        {
            var aeroport = aeroports.FirstOrDefault(a => a.Nom == ancienNom);
            if (aeroport == null)
                throw new ArgumentException("Aéroport non trouvé : " + ancienNom);
            
            aeroport.Nom = nouveauNom;
            aeroport.Position = position;
            aeroport.MinPassagers = minPassagers;
            aeroport.MaxPassagers = maxPassagers;
            aeroport.MinCargaisons = minCargaisons;
            aeroport.MaxCargaisons = maxCargaisons;

            Notifier();
        }


        public void SupprimerAeroport(string nom)
        {
            var aeroport = aeroports.FirstOrDefault(a => a.Nom.Equals(nom, StringComparison.OrdinalIgnoreCase));
            if (aeroport != null)
            {
                aeroports.Remove(aeroport);
                Notifier(); 
            }
        }

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        public Aeroport ObtenirAeroportSelectionne(string nomAeroport)
        {
            if (string.IsNullOrEmpty(nomAeroport))
            {
                return null;
            }
            return aeroports.FirstOrDefault(a => a.Nom.Equals(nomAeroport, StringComparison.OrdinalIgnoreCase));
        }

    }
}
