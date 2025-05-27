using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    class EtatEntretien : EtatAeronef
    {
        public override void AvancerPas(double pas)
        {
            Console.WriteLine($"[Entretien] Aéronef en entretien pendant {pas} pas.");
        }

        public override TypeEtat GetTypeEtat()
        {
            return TypeEtat.Entretien;
        }
        
    }
}
