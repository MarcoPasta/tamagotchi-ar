using System.Collections.Generic;
using Modules;
using UnityEngine;

public class StateController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IState hungerState = new State(1.0, 0, 1.0);
        IState happinessState = new State(1.0, 0, 1.0);

        List<IState> healthStateDependents = new List<IState> { hungerState, happinessState };
        
        IState healthState = new State(1.0, 0, 1.0, healthStateDependents);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
