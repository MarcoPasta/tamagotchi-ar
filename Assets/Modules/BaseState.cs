using System.Collections.Generic;

namespace Modules
{
    public abstract class BaseState : IState
    {
        public abstract double RangeMin { get; }
        public abstract double RangeMax { get; }
        
        private double _stateValue;
        
        public double StateValue
        {
            get => _stateValue;
            set => _stateValue = Helpers.Clamp(value, RangeMin, RangeMax);
        }

        public void Increase(double value, double factor = 1)
        {
            var valueToIncreaseBy = factor * value;
            StateValue += valueToIncreaseBy;
        }

        public void Decrease(double value, double factor = 1)
        {
            var valueToDecreaseBy = factor * value;
            StateValue -= valueToDecreaseBy;
        }
    }
}