using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gererateur_Scenario.Controle;

namespace Gererateur_Scenario
{
    class Program
    {
        static void Main(string[] args)
        {
            var controlleGenerateur = new ControleurGenerateur();
            controlleGenerateur.DemarrerApplication();
        }
    }
}
