using System.Collections.Generic;
using Modules.State;
using UnityEngine;

public class StateController : MonoBehaviour
{
    private IState _hungerState;
    private IState _happinessState;
    private IState _healthState;
    
    // Start is called before the first frame update
    void Start()
    {
        _hungerState = new State(1.0, 0, 1.0);
        _happinessState = new State(1.0, 0, 1.0);

        List<IStateDependency> healthStateDependencies = new List<IStateDependency>
        {
            new StateDependency(_hungerState, 0.5), 
            new StateDependency(_happinessState, 0.5), 
        };
        
        _healthState = new State(1.0, 0, 1.0, healthStateDependencies);
    }

    // Update is called once per frame
    void Update()
    {
        _hungerState.Value -= 0.00000001;
        _healthState.UpdateStateValue();
        Debug.Log(_healthState.Value);
    }
}
