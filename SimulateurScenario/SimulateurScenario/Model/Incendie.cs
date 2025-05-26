using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public class Incendie : ClientEvenement
    {
        public int Intensite { get; set; }
        private bool eteint = false;

        public override void Traiter(Aeronef aeronef)
        {
            Console.WriteLine($"Intervention sur incendie d’intensité {Intensite}.");
            eteint = true;
        }

        public override bool estTermine()
        {
            return eteint;
        }
    }
}
