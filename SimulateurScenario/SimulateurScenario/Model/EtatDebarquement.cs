using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    class EtatDebarquement : EtatAeronef
    {
        public override void AvancerPas(double pas)
        {
            Console.WriteLine($"[Démbarquement] Aéronef en embarquement pendant {pas} pas.");
        }

        public override TypeEtat GetTypeEtat()
        {
            return TypeEtat.Embarquement;
        }
    }
}
