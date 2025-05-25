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
        private FabriqueClient() { }
        //public Client CreerClient(){}
    }
}
