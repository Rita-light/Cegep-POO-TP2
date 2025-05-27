using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    class EtatVol : EtatAeronef
    {
        public override void AvancerPas(double pas)
        {
            Console.WriteLine($"[Vol] Aéronef en vol pendant {pas} pas.");
        }

        public override TypeEtat GetTypeEtat()
        {
            return TypeEtat.Vol;
        }
    }
}
