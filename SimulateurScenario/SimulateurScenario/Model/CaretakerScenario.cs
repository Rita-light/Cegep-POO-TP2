namespace SimulateurScenario.Model;

public class CaretakerScenario
{
    private ScenarioMemento _mementoInitial;

    public void EnregistrerEtatInitial(Scenario scenario)
    {
        _mementoInitial = scenario.CreateMemento();
    }

    public void RestaurerEtatInitial(Scenario scenario)
    {
        scenario.RestoreMemento(_mementoInitial);
    }
}
