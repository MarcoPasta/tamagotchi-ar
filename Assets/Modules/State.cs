using System.Collections.Generic;

namespace Modules
{
    public class State : BaseState
    {
        public override double RangeMin { get; }
        public override double RangeMax { get; }
        
        public override List<IState> Dependents { get; }

        public State(double stateValue, double rangeMin, double rangeMax, List<IState> dependents = null)
        {
            RangeMin = rangeMin;
            RangeMax = rangeMax;
            StateValue = stateValue;
            Dependents = dependents;
        }
    }
}