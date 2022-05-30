namespace Modules.State
{
    /// <summary>
    /// This class implements the <c>IStateDependency</c> interface.
    /// </summary>
    public class StateDependency : IStateDependency
    {
        /// <inheritdoc />
        public IState State { get; }

        /// <inheritdoc />
        public double Weighting { get; }

        /// <summary>
        /// This constructor initializes a <c>StateDependency</c>.
        /// </summary>
        /// <param name="state">The State that should become a dependency.</param>
        /// <param name="weighting">The associated weighting.</param>
        public StateDependency(IState state, double weighting)
        {
            State = state;
            Weighting = weighting;
        }
    }
}