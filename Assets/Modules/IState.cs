using System.Collections.Generic;

namespace Modules
{
    /// <summary>
    /// Interface <c>IState</c> defines the contract, which a State must fulfill.
    /// It must implement a minimum and a maximum state value, the value itself, a list of dependencies and
    /// a method to update said value.
    /// </summary>
    public interface IState
    {
        /// <value>Defines the lowest possible state value.</value>
        double RangeMin { get; }
        /// <value>Defines the highest possible state value.</value>
        double RangeMax { get; }

        /// <value>Defines a list of <c>IStateDependency</c> dependencies.</value>
        List<IStateDependency> Dependencies { get; }

        /// <value>Defines the state value itself. It will be clamped to fit into the given range.</value>
        double Value
        {
            get;
            set;
        }

        /// <summary>
        /// This method is used for updating the state value and should be implemented accordingly.
        /// </summary>
        public void UpdateStateValue();
    }
}