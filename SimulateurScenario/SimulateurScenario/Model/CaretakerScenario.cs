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
        if (_mementoInitial != null)
        {
            scenario.RestoreMemento(_mementoInitial);
        }
    }
}
