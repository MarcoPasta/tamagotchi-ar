namespace Modules
{
    public class HungerState : BaseState
    {
        public override double RangeMin { get; }
        public override double RangeMax { get; }
        
        public HungerState(double stateValue, double rangeMin, double rangeMax)
        {
            StateValue = stateValue;
            RangeMin = rangeMin;
            RangeMax = rangeMax;
        }
    }
}
