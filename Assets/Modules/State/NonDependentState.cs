using System.Collections.Generic;

namespace Modules.State
{
    /// <summary>
    /// Class <c>State</c> represents a value between <c>RangeMin</c> and <c>RangeMax</c>, which can be increased, decreased,
    /// or be dependent on other state values.
    /// </summary>
    public class NonDependentState : BaseState
    {
        /// <inheritdoc />
        public override double RangeMin { get; }

        /// <inheritdoc />
        public override double RangeMax { get; }

        public override List<IStateDependency> Dependencies { get; }

        /// <summary>
        /// This method updates the state value by iterating through all the <c>Dependencies</c>,
        /// adding all the weighted dependency's states together.
        /// </summary>
        public override void UpdateStateValue(double decrease = 0)
        {
            Value -= decrease;
        }

        /// <summary>
        /// This constructor initializes a new State with the given arguments.
        /// </summary>
        /// <param name="name">The name of the state.</param>
        /// <param name="value">The starting value.</param>
        /// <param name="rangeMin">The lowest possible state value.</param>
        /// <param name="rangeMax">The highest possible state value.</param>
        public NonDependentState(string name, double value, double rangeMin, double rangeMax)
        {
            Name = name;
            RangeMin = rangeMin;
            RangeMax = rangeMax;
            Value = value;
            Dependencies = null;
        }
    }
}