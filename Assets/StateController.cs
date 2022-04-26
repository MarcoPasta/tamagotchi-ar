using Modules;
using UnityEngine;

public class StateController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IState healthState = new HealthState(100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
