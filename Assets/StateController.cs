using System.Collections.Generic;
using System.Linq;
using Modules.State;
using Modules.Timestamp;
using UnityEngine;

public class StateController : MonoBehaviour
{
    private List<IState> _states;
    private int _minutesPassedSinceLastPlayed;
    private const double DecreasePerTick = 0.000001;
    
    // Start is called before the first frame update
    void Start()
    {
        IState hungerState = new State(1.0, 0, 1.0);
        IState happinessState = new State(1.0, 0, 1.0);

        List<IStateDependency> healthStateDependencies = new List<IStateDependency>
        {
            new StateDependency(hungerState, 0.5), 
            new StateDependency(happinessState, 0.5)
        };
        
        IState healthState = new State(1.0, 0, 1.0, healthStateDependencies);

        _states = new List<IState> { hungerState, happinessState, healthState };
    }

    // Update is called once per frame
    void Update()
    {
        if (_states == null)
        {
            return;
        }
        
        foreach (var state in _states)
        {
            state.UpdateStateValue();
        }
    }
    
    private void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            HandleGameReturn();
            return;
        }
        
        HandleGameQuit();
    }

    private static void HandleGameQuit()
    {
        Timestamp.Save();
    }

    private void HandleGameReturn()
    {
        _minutesPassedSinceLastPlayed = Timestamp.GetDifferenceInMinutes();

        if (_states == null)
        {
            return;
        }
        
        foreach (var state in _states)
        {
            state.Value -= CalculateStateValueDecrease(_minutesPassedSinceLastPlayed);
        }
    }

    private static double CalculateStateValueDecrease(int minutes)
    {
        return minutes * 60 * 60 * DecreasePerTick;
    }
}
