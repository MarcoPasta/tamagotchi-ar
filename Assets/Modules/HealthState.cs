﻿namespace Modules
{
    public class HealthState : BaseState
    {
        public override double RangeMin { get; }
        public override double RangeMax { get; }
        
        public HealthState(double stateValue, double rangeMin, double rangeMax)
        {
            RangeMin = rangeMin;
            RangeMax = rangeMax;
            StateValue = stateValue;
        }
    }
}