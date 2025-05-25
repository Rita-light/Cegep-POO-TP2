using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gererateur_Scenario.Controle;
using Gererateur_Scenario.Vue;

namespace Gererateur_Scenario
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
              
            //var controlleGenerateur = new ControleurGenerateur();
            //controlleGenerateur.DemarrerApplication();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new FormGenerateur();                   // 1. Créer la vue
            var controleur = new ControleurGenerateur(form);   // 2. Passer la vue au contrôleur
            form.SetControleur(controleur);                    // 3. Passer le contrôleur à la vue

            Application.Run(form);        
        }
    }
}
