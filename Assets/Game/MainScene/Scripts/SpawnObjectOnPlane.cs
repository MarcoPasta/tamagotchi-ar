using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
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

        private void Awake()
        {
            _raycastManager = GetComponent<ARRaycastManager>();
        }

        private static bool TryGetTouchPosition(out Vector2 touchPosition)
        {
            if (Input.touchCount > 0)
            {
                touchPosition = Input.GetTouch(0).position;
                return true;
            }

            touchPosition = default;
            return false;
        }

        // Update is called once per frame
        private void Update()
        {
            if (!TryGetTouchPosition(out Vector2 touchPosition))
            {
                return;
            }

            if (_raycastManager.Raycast(touchPosition, _raycastHits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = _raycastHits[0].pose;

                if (_spawnedObject == null)
                {
                    _spawnedObject = Instantiate(placeablePrefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    _spawnedObject.transform.position = hitPose.position;
                    _spawnedObject.transform.rotation = hitPose.rotation;
                }
            }
        }
    }
}
