using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Game.MainScene.Scripts
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class SpawnObjectOnPlane : MonoBehaviour
    {
        private ARRaycastManager _raycastManager;
        private GameObject _spawnedObject;

        [SerializeField]
        private GameObject placeablePrefab;

        private static List<ARRaycastHit> _raycastHits = new List<ARRaycastHit>();
        
        public Button miniGameButton;

        private bool _isInMiniGame = false; 

        private void Awake()
        {
            _raycastManager = GetComponent<ARRaycastManager>();
        }

        private static bool TryGetTouchPosition(out Vector2 touchPosition)
        {
            // Debug.Log("Trying to get a touch position...");
            if (Input.touchCount > 0)
            {
                touchPosition = Input.GetTouch(0).position;
                // Debug.Log($"Touch occured at position {touchPosition}.");
                return true;
            }

            touchPosition = default;
            // Debug.Log($"No touch occured. touchPosition = {touchPosition}");
            return false;
        }

        // Update is called once per frame
        private void Update()
        {
            if (!_isInMiniGame)
            {
                if (!TryGetTouchPosition(out Vector2 touchPosition))
                {
                    return;
                }

                // Debug.Log($"Casting ray on touch position: {touchPosition}");
            
                if (_raycastManager.Raycast(touchPosition, _raycastHits, TrackableType.PlaneWithinPolygon))
                {
                    var hitPose = _raycastHits[0].pose;
                    // Debug.Log($"Hit pose: {hitPose}.");

                    if (_spawnedObject == null)
                    {
                        // Debug.Log($"Trying to instantiate prefab at {hitPose.position} with rotation {hitPose.rotation}.");
                        _spawnedObject = Instantiate(placeablePrefab, hitPose.position, hitPose.rotation);
                    }
                    else
                    {
                        // Debug.Log($"Moving {_spawnedObject} to {hitPose.position} with rotation {hitPose.rotation}.");
                        _spawnedObject.transform.position = hitPose.position;
                        _spawnedObject.transform.rotation = hitPose.rotation;
                    }
                }
            }
            
            // listen if a button is clicked to destroy the object
            miniGameButton.onClick.AddListener(DestroyChar);
        }

        private void DestroyChar()
        {
            Debug.Log("Destroyed Character");
            Destroy(_spawnedObject);
            _isInMiniGame = true;
        }
    }
}
