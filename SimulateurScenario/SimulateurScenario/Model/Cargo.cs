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
        public Aeroport Destination { get; set; }
        private bool termine = false;

        public override void Traiter(Aeronef aeronef)
        {
            Console.WriteLine($"Cargaison de {PoidsCargaison} tonnes embarquée vers {Destination.Nom}.");
            termine = true;
        }

        public override bool estTermine()
        {
            return termine;
        }
    }
}
