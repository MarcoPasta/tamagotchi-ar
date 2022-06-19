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
    public class SetReferencePoint : MonoBehaviour
    {
        private ARRaycastManager _raycastManager;
        
        private static readonly List<ARRaycastHit> RaycastHits = new();

        public GameObject referencePoint;
        
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

            if (_raycastManager.Raycast(touchPosition, RaycastHits, TrackableType.PlaneWithinPolygon))
            {
                var hit = RaycastHits[0];
                var hitPose = hit.pose;

                referencePoint.transform.position = hitPose.position;
            }
        }
    }
}
