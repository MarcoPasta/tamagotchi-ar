using System.Collections.Generic;

namespace Modules
{
    public interface IState
    {
        double RangeMin { get; }
        double RangeMax { get; }

        List<IStateDependency> Dependencies { get; }

        double Value
        {
            get;
            set;
        }

        public void UpdateStateValue();
    }
}