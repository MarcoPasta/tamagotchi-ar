namespace Modules.State
{
    /// <summary>
    /// This interface describes a state dependency, mapping a <c>State</c> and its <c>Weighting</c>. 
    /// </summary>
    public interface IStateDependency
    {
        /// <value>The <c>State</c> that represents a dependency.</value>
        public IState State { get; }
        /// <value>The Weighting associated with the <c>State</c>.</value>
        public double Weighting { get; }
    }
}