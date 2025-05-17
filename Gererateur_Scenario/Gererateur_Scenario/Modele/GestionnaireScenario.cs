using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    class GestionnaireScenario
    {
        private static GestionnaireScenario _instance;
        private static readonly object _lock = new object();
        private Scenario m_scenario  ;

        private GestionnaireScenario()
        {
            m_scenario = new Scenario();
        }
        public static GestionnaireScenario Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new GestionnaireScenario();
                    }
                    return _instance;
                }
            }
        }
        public Scenario GetScenario() => m_scenario;

        public void SetScenarioActuel(Scenario scenario)
        {
            m_scenario = scenario;
        }

        public void NouveauScenario()
        {
            m_scenario = new Scenario();
        }

        public List<string> ObtenirListeAeroports()
        {
            return m_scenario.ObtenirListeAeroports();
        }

        public List<string> ObtenirListeAeronefs(string nomAeroport)
        {
            return m_scenario.ObtenirListeAeronefs(nomAeroport);
        }

        public Aeroport ObtenirAeroportSelectionne(string nomAeroport)
        {
            return m_scenario.ObtenirAeroportSelectionne(nomAeroport);
        }

        public void ChangerFrequence(TypeEvenement type, string frequenceTextBox)
        {
            //Si la string entrée par l'utilisateur dans le textbox n'est pas convertible en double ou si elle est négative, on lève une exception
            if (!double.TryParse(frequenceTextBox, out double valeur) || valeur < 0)
                throw new ArgumentException("Fréquence invalide");
            //On compare la valeur entrée par l'utilisateur avec la valeur actuelle de la fréquence
            foreach (FrequenceEvenement frequence in m_scenario.frequenceEvenements)
            {
                //Si la fréquence du type d'évènement existe déjà, on la modifie
                if (frequence.Type == type)
                {
                    frequence.Frequence = valeur;
                    return;
                }
            }
            //Si la fréquence n'existe pas, on l'ajoute à la liste
            m_scenario.frequenceEvenements.Add(new FrequenceEvenement
            {
                Type = type,
                Frequence = valeur
            });
        }

        //On récupère la fréquence d'un événement
        public double GetFrequence(TypeEvenement type)
        {   //On retourne la fréquence de l'événement passé en paramètre
            foreach (FrequenceEvenement frequence in m_scenario.frequenceEvenements)
            {
                if (frequence.Type == type)
                    return frequence.Frequence;
            }
            //Si la fréquence n'existe pas, on lève une exception
            throw new ArgumentException("Type d'événement non trouvé");
        }
    }
}
