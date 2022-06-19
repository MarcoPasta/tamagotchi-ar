using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    public GameObject cube;
    public GameObject plane;
    public TextMeshProUGUI debug;

    // Update is called once per frame
    void Update()
    {
        debug.text = "cubes position: " + cube.transform.position + 
                     "\nplane position: " + plane.transform.position;
    }
}
