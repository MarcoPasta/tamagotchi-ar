namespace Modules
{
    public class StateDependency : IStateDependency
    {
        public IState State { get; }
        public double Weighting { get; }

        public StateDependency(IState state, double weighting)
        {
            State = state;
            Weighting = weighting;
        }
    }
}