namespace Modules
{
    public class State : IState
    {
        private const double RangeMin = 0;
        private const double RangeMax = 1.0;

        private double _stateValue;
        public double StateValue
        {
            get => _stateValue;
            set => _stateValue = Helpers.Clamp(value, RangeMin, RangeMax);
        }

        public State(int value)
        {
            StateValue = value;
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