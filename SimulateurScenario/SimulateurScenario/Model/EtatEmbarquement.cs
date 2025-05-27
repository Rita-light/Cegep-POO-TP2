using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    class EtatEmbarquement : EtatAeronef
    {
        public override void AvancerPas(double pas)
        {
            Console.WriteLine($"[Ebarquement] Aéronef en débarquement pendant {pas} pas.");
        }

        public override TypeEtat GetTypeEtat()
        {
            return TypeEtat.Debarquement;
        }
    }
}
