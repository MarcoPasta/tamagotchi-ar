using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARCursor : MonoBehaviour
{
    public GameObject cursorChildObject;
    public GameObject objectToPlace;
    public ARRaycastManager raycastManager;
    public Camera mainCamera;

    private Transform cursor; 
    
    public bool useCursor = true; 
    // Start is called before the first frame update
    private void Start()
    {
        cursorChildObject.SetActive(useCursor);
    }

    // Update is called once per frame
    private void Update()
    {
        if (useCursor)
        {
            // update cursors position for each frame
            UpdateCursor();
        }

        if (Input.touchCount <= 0 || Input.GetTouch(0).phase != TouchPhase.Began) return;
        if (useCursor)
        {
            // // create object
            Instantiate(objectToPlace, cursor.position, cursor.rotation);
        }
        else
        {
            // create list for raycasthits
            var hits = new List<ARRaycastHit>();
            // send a raycast 
            raycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.Planes);
            if (hits.Count > 0)
            {
                Instantiate(objectToPlace, hits[0].pose.position, hits[0].pose.rotation);
            }
        }
    }

    private void UpdateCursor()
    {
        // get the centered position of the screen to cast ray from 
        Vector2 screenPosition = mainCamera.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        // create list of raycasts that hit a surface
        var hits = new List<ARRaycastHit>();
        // cast ray against the planes
        raycastManager.Raycast(screenPosition, hits, TrackableType.Planes);
        // when hit a plane, get the closest point
        if (hits.Count <= 0) return;
        cursor.position = hits[0].pose.position;
        cursor.rotation = hits[0].pose.rotation;
    }
}
