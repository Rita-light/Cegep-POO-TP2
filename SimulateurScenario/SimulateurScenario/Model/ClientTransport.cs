using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public abstract class ClientTransport : Client
    {
        public Aeroport Destination { get; set; }
        
        protected ClientTransport() { }

        protected ClientTransport(Position position, Aeroport destination)
            : base(position)
        {
            Destination = destination;
        }
    }

}
