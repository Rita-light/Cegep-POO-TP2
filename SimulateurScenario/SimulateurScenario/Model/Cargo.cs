using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public class  Cargo :ClientTransport
    {
        public double PoidsCargaison { get; set; }
        private bool termine = false;

        public Cargo() { }

        public Cargo(Position position, Aeroport destination, double poids)
            : base(position, destination)
        {
            PoidsCargaison = poids;
        }

        public override void Traiter(Aeronef aeronef)
        {
            Console.WriteLine($"Cargaison de {PoidsCargaison} tonnes embarquée vers {Destination.Nom}.");
            termine = true;
        }

        public override bool estTermine()
        {
            return termine;
        }
        public override Client Clone()
        {
            return new Cargo(position?.Clone(), Destination, PoidsCargaison);
        }
    }
}
