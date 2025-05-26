using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public abstract class Client
    {
        Position position;

        public abstract void Traiter(Aeronef aeronef);
        public abstract bool estTermine();
    }
}
