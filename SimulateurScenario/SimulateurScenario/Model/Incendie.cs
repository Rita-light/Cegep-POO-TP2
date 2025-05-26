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
        
        public Incendie() { }

        public Incendie(Position position, int intensite)
            : base(position)
        {
            Intensite = intensite;
        }

        public override void Traiter(Aeronef aeronef)
        {
            Console.WriteLine($"Intervention sur incendie d’intensité {Intensite}.");
            eteint = true;
        }

        public override bool estTermine()
        {
            return eteint;
        }
        
        public override Client Clone()
        {
            return new Incendie
            {
                position = this.position?.Clone(),
                Intensite = this.Intensite
            };
        }
    }
}
