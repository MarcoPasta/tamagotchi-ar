using System.Collections.Generic;

namespace Modules
{
    public abstract class BaseState : IState
    {
        public abstract double RangeMin { get; }
        public abstract double RangeMax { get; }
        public abstract List<IStateDependency> Dependencies { get; }

        private double _stateValue;
        
        public double Value
        {
            get => _stateValue;
            set => _stateValue = Helpers.Clamp(value, RangeMin, RangeMax);
        }

        public abstract void UpdateStateValue();
    }
}