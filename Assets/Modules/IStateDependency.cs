namespace Modules
{
    public interface IStateDependency
    {
        public IState State { get; }
        public double Weighting { get; }
    }
}