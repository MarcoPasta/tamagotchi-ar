using System.Collections.Generic;

namespace Modules
{
    public class State : BaseState
    {
        public override double RangeMin { get; }
        public override double RangeMax { get; }
        
        public override List<IStateDependency> Dependencies { get; }
        public override void UpdateStateValue()
        {
            if (Dependencies.Count == 0)
            {
                return;
            }

            double newStateValue = 0;
            
            foreach (IStateDependency stateDependency in Dependencies)
            {
                double weightedDependencyValue = stateDependency.State.Value * stateDependency.Weight;
                newStateValue += weightedDependencyValue;
            }

            Value = newStateValue;
        }

        public State(double value, double rangeMin, double rangeMax, List<IStateDependency> dependencies = null)
        {
            RangeMin = rangeMin;
            RangeMax = rangeMax;
            Value = value;
            Dependencies = dependencies;
        }
    }
}