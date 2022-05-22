using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager _rayManager;
    private GameObject _visual;
    public Camera mainCamera;

    // Start is called before the first frame update
    private void Start()
    {
        
        // get the components
        _rayManager = FindObjectOfType<ARRaycastManager>();
        _visual = transform.GetChild(0).gameObject;
        // hide the placement indicator visual
        _visual.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateIndicator();
        
    }

    private void UpdateIndicator()
    {
        Vector2 screenPosition = mainCamera.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        _rayManager.Raycast(screenPosition, hits, TrackableType.Planes);
        if (hits.Count <= 0) return;
        var tVisual = transform;
        tVisual.position = hits[0].pose.position;
        tVisual.rotation = hits[0].pose.rotation;
        
        if (!_visual.activeInHierarchy)
            _visual.SetActive(true);
    }

}

