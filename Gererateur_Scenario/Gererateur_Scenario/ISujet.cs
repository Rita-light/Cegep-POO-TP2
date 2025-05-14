namespace Gererateur_Scenario
{
    public interface ISujet
    {
        void Attacher(IObservateur obs);
        void Detacher(IObservateur obs);
        void Notifier();
    }
}