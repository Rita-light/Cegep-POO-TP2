namespace SimulateurScenario.Model;

public class ScenarioMemento
{
    public List<Aeroport> Aeroports { get; }

    public ScenarioMemento(List<Aeroport> aeroports)
    {
        // Profonde copie si nécessaire
        Aeroports = aeroports.Select(a => a.Clone()).ToList();
    }
}