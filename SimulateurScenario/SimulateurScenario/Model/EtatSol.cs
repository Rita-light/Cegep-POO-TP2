using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    class EtatSol : EtatAeronef
    {
        public override void AvancerPas(double pas)
        {
            Console.WriteLine($"[Sol] Aéronef stationné pendant {pas} pas.");
        }

        public override TypeEtat GetTypeEtat()
        {
            return TypeEtat.Sol;
        }
    }
}
