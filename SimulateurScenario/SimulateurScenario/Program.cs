using SimulateurScenario.Controleur;

namespace SimulateurScenario;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
        form_Simulateur formSimulateur = new form_Simulateur();
        ControleurSimulateur controleurSimulateur = new ControleurSimulateur(formSimulateur);
        Application.Run(formSimulateur);
    }
}