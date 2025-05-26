using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public abstract class Client
    {
        public Position position;
        protected Client() { }

        protected Client(Position pos)
        {
            position = pos;
        }

        public abstract void Traiter(Aeronef aeronef);
        public abstract bool estTermine();
        public abstract Client Clone();
    }
}
