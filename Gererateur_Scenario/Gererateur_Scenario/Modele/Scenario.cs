using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    public class Scenario
    {
        private List<Aeroport> m_aeroport { get; set; }
        private List<FrequenceEvenement> m_frequence { get; set; } = new List<FrequenceEvenement>();
        private List<IObservateur> m_observateurs = new List<IObservateur>();

        public Scenario()
        {
            m_aeroport = new List<Aeroport>();
            m_frequence = new List<FrequenceEvenement>();
            m_observateurs = new List<IObservateur>();
        }

        

        public List<Aeroport> GetAeroports()
        {
            return m_aeroport;
        }
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
            m_aeroport.Add(aeroport);
            Notifier();
        }


        public List<string> ObtenirListeAeroports()
        {
            List<string> liste = new List<string>();

            foreach (var aeroport in m_aeroport)
            {
                liste.Add(aeroport.Serialiser());
            }

            return liste;
        }

        public List<string> ObtenirListeAeronefs(string nomAeroport)
        {
            foreach (var aeroport in m_aeroport)
            {
                if (aeroport.Nom == nomAeroport)
                {
                    return aeroport.ObtenirListeAeronefs();
                }
            }

            return new List<string>();
        }

        public void ModifierAeroport(string ancienNom, string nouveauNom, Position position, int minPassagers, int maxPassagers, double minCargaisons, double maxCargaisons)
        {
            var aeroport = m_aeroport.FirstOrDefault(a => a.Nom == ancienNom);
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
            var aeroport = m_aeroport.FirstOrDefault(a => a.Nom.Equals(nom, StringComparison.OrdinalIgnoreCase));
            if (aeroport != null)
            {
                m_aeroport.Remove(aeroport);
                Notifier();
            }
        }

        public Aeroport ObtenirAeroportSelectionne(string nomAeroport)
        {
            if (string.IsNullOrEmpty(nomAeroport))
            {
                return null;
            }
            return m_aeroport.FirstOrDefault(a => a.Nom.Equals(nomAeroport, StringComparison.OrdinalIgnoreCase));
        }

        public double GetFrequence(TypeEvenement type)
        {
            var frequence = m_frequence.FirstOrDefault(f => f.Type == type);
            if (frequence != null)
            {
                return frequence.Frequence;
            }
            else
            {
                throw new ArgumentException("Type d'événement non trouvé : " + type);
            }
        }

        public List<FrequenceEvenement> GetFrequences()
        {
            return m_frequence;
        }

        public void ChangerFrequence(TypeEvenement type, string frequenceTextBox)
        {
            //Si la string entrée par l'utilisateur dans le textbox n'est pas convertible en double ou si elle est négative, on lève une exception
            if (!double.TryParse(frequenceTextBox, out double valeur) || valeur < 0)
                throw new ArgumentException("Fréquence invalide");
            //On compare la valeur entrée par l'utilisateur avec la valeur actuelle de la fréquence
            var frequenceExiste = m_frequence.FirstOrDefault(f => f.Type == type);

            if (frequenceExiste != null)
            {
                //Si la fréquence du type d'évènement existe déjà, on la modifie
                frequenceExiste.Frequence = valeur;
            }
            else
            {
                //Sinon, on crée une nouvelle fréquence
                m_frequence.Add(new FrequenceEvenement(type, valeur));
            }
        }
    }
}