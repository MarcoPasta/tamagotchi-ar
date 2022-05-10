namespace Modules
{
    public class StateDependency : IStateDependency
    {
        public IState State { get; }
        public double Weight { get; }

        public StateDependency(IState state, double weight)
        {
            State = state;
            Weight = weight;
        }
    }
}