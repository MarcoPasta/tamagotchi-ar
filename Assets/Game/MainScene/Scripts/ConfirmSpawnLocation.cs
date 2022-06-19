using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Game.MainScene.Scripts
{
    public class ConfirmSpawnLocation : MonoBehaviour
    {
        public GameObject[] objectsToActivate;
        public GameObject[] objectsToDeactivate;
        public GameObject referencePoint;
        public GameObject tamagotchi;

        public void ConfirmSpawn()
        {
            GameObject arSessionOrigin = GameObject.Find("AR Session Origin");
            ARPlaneManager planeManager = arSessionOrigin.GetComponent<ARPlaneManager>();
            planeManager.requestedDetectionMode = PlaneDetectionMode.None;

            arSessionOrigin.GetComponent<SetReferencePoint>().enabled = false;
            
            foreach (var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
            
            foreach (var objectToActivate in objectsToActivate)
            {
                objectToActivate.SetActive(true);
            }
            
            foreach (var objectToDeactivate in objectsToDeactivate)
            {
                objectToDeactivate.SetActive(false);
            }
            Debug.Log("placing Tamagotchi");
            Instantiate(tamagotchi, referencePoint.transform);
            referencePoint.transform.GetChild(0).gameObject.SetActive(false); // set false so the orange won't be visible in here anymore
        }
    }
}
