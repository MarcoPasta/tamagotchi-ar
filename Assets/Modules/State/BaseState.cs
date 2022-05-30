using System.Collections.Generic;

namespace Modules.State
{
    /// <summary>
    /// Class <c>BaseState</c> implements the <c>IState</c> interface with abstract range members,
    /// a default state value implementation for all inheriting classes
    /// and an abstract method for updating the state value.
    /// </summary>
    public abstract class BaseState : IState
    {
        /// <inheritdoc />
        public abstract double RangeMin { get; }

        /// <inheritdoc />
        public abstract double RangeMax { get; }

        /// <inheritdoc />
        public abstract List<IStateDependency> Dependencies { get; }

        /// <value>Private helper property to get computed state value.</value>
        private double _stateValue;

        /// <inheritdoc />
        public double Value
        {
            get => _stateValue;
            set => _stateValue = Helpers.Clamp(value, RangeMin, RangeMax);
        }


        /// <inheritdoc />
        public abstract void UpdateStateValue();
    }
}