using System.Collections;
using System.Collections.Generic;
using Modules;
using UnityEngine;

public class StateController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Modules.IState healthState = new State();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
