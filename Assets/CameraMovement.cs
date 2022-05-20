using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public float speed = 20.0f;
    public float rotateSpeed = 70.0f;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.L))
        {
            transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime,0));
        }
        
        if (Input.GetKey(KeyCode.J))
        {
            transform.Rotate(new Vector3(0, -rotateSpeed * Time.deltaTime,0));
        }
        
        if (Input.GetKey(KeyCode.K))
        {
            transform.Rotate(new Vector3(rotateSpeed * Time.deltaTime, 0,0));
        }
        
        if (Input.GetKey(KeyCode.I))
        {
            transform.Rotate(new Vector3(-rotateSpeed * Time.deltaTime, 0,0));
        }

        if (Input.GetKey(KeyCode.U))
        {
            transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.O))
        {
            transform.Rotate(new Vector3(0, 0, -rotateSpeed * Time.deltaTime));
        }

    }
}
