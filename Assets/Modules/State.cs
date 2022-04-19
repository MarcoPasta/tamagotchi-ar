namespace Modules
{
    public class State : IState
    {
        private const int RangeMin = 0;
        private const int RangeMax = 100;

        private int _stateValue;
        public int StateValue
        {
            get => _stateValue;
            set => _stateValue = Helpers.Clamp(value, RangeMin, RangeMax);
        }
        public int IncreaseFactor { get; set; }
        public int DecreaseFactor { get; set; }

        public State(int value)
        {
            StateValue = value;
        }
        
        public void Increase(int value)
        {
            var valueToIncreaseBy = IncreaseFactor * value + StateValue;
            StateValue += valueToIncreaseBy;
        }

        public void Decrease(int value)
        {
            var valueToDecreaseBy = DecreaseFactor * value + StateValue;
            StateValue += valueToDecreaseBy;
        }
    }
}