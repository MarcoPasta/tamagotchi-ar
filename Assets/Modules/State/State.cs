using System.Collections.Generic;

namespace Modules.State
{
    /// <summary>
    /// Class <c>State</c> represents a value between <c>RangeMin</c> and <c>RangeMax</c>, which can be increased, decreased,
    /// or be dependent on other state values.
    /// </summary>
    public class State : BaseState
    {
        /// <inheritdoc />
        public override double RangeMin { get; }

        /// <inheritdoc />
        public override double RangeMax { get; }

        /// <inheritdoc />
        public override List<IStateDependency> Dependencies { get; }

        /// <summary>
        /// This method updates the state value by iterating through all the <c>Dependencies</c>,
        /// adding all the weighted dependency's states together.
        /// </summary>
        public override void UpdateStateValue()
        {
            if (Dependencies.Count == 0)
            {
                return;
            }

            double newStateValue = 0;
            
            foreach (IStateDependency stateDependency in Dependencies)
            {
                double weightedDependencyValue = stateDependency.State.Value * stateDependency.Weighting;
                newStateValue += weightedDependencyValue;
            }

            Value = newStateValue;
        }

        /// <summary>
        /// This constructor initializes a new State with the given arguments.
        /// </summary>
        /// <param name="value">The starting value.</param>
        /// <param name="rangeMin">The lowest possible state value.</param>
        /// <param name="rangeMax">The highest possible state value.</param>
        /// <param name="dependencies">A list of <c>IStateDependency</c> instances</param>
        public State(double value, double rangeMin, double rangeMax, List<IStateDependency> dependencies = null)
        {
            RangeMin = rangeMin;
            RangeMax = rangeMax;
            Value = value;
            Dependencies = dependencies;
        }
    }
}