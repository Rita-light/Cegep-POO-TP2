using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public class Secours : ClientEvenement
    {
        private bool termine = false;

        public override void Traiter(Aeronef aeronef)
        {
            Console.WriteLine("Mission de secours effectuée.");
            termine = true;
        }

        public override bool estTermine()
        {
            return termine;
        }
    }
}
