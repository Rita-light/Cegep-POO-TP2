using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    class Passager : ClientTransport
    {
        public int NbPassagers { get; set; }
        private bool termine = false;
        
        public Passager() { }

        public Passager(Position position, Aeroport destination, int nbPassagers)
            : base(position, destination)
        {
            NbPassagers = nbPassagers;
        }
        public override void Traiter(Aeronef aeronef)
        {
            // Exemple simple : Embarquement puis marquer comme terminé
            Console.WriteLine($"Passagers embarqués vers {Destination.Nom}.");
            termine = true;
        }
        public override bool estTermine()
        {
            return termine;
        }
        public override Client Clone()
        {
            return new Passager
            {
                position = this.position?.Clone(),
                Destination = this.Destination, // Clonage optionnel
                NbPassagers = this.NbPassagers
            };
        }
    }
}
