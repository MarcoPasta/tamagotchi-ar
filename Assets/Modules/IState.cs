using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Modules
{
    public interface IState
    {
        double RangeMin { get; }
        double RangeMax { get; }

        List<IState> Dependents { get; }

        double StateValue
        {
            get;
            set;
        }
        
        void Increase(double value, double factor = 1);
        void Decrease(double value, double factor = 1);
    }
}