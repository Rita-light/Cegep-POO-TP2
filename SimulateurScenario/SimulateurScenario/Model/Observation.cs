using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public class Observation : ClientEvenement
    {
        private bool termine = false;

        public Observation() { }

        public Observation(Position position)
            : base(position)
        {
        }
        public override void Traiter(Aeronef aeronef)
        {
            Console.WriteLine("Observation effectuée sur zone.");
            termine = true;
        }

        public override bool estTermine()
        {
            return termine;
        }
        
        public override Client Clone()
        {
            return new Observation(position?.Clone());
        }
    }
}
