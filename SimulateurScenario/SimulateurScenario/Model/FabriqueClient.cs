using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    class FabriqueClient
    {

        private static FabriqueClient instance;
        private static readonly object padlock = new object();

        public static FabriqueClient Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new FabriqueClient();
                    }

                    return instance;
                }
            }
        }

        private FabriqueClient()
        {
        }

        //public Client CreerClient(){}
        public Client CreerClient(Evenement e)
        {Console.WriteLine($"Type d'événement reçu: {e.typeEvenement}");
            switch (e.typeEvenement)
            { 
                case TypeEvenement.Passager:
                    return new Passager
                    {
                        NbPassagers = e.NombrePassagers ?? 1,
                        Destination = e.Destination
                    };
                case TypeEvenement.Cargaison:
                    return new Cargo
                    {
                        PoidsCargaison = e.PoidsCargo ?? 1.0,
                        Destination = e.Destination
                    };
                case TypeEvenement.Secours:
                    return new Secours(e.position); 
                case TypeEvenement.Incendie:
                    return new Incendie (e.position, e.Intensite ?? 5);
                case TypeEvenement.Observation:
                    return new Observation(e.position);
                default:
                    throw new ArgumentException("Type d'événement non reconnu.");
            }
        }
    }
}
