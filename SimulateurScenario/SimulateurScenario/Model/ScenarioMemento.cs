namespace SimulateurScenario.Model;

public class ScenarioMemento
{
    public List<Aeroport> Aeroports { get; }

    public ScenarioMemento(List<Aeroport> aeroports)
    {
        Aeroports = aeroports.Select(a => a.Clone()).ToList();
    }
}