using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Game.MainScene.Scripts
{
    public class ConfirmSpawnLocation : MonoBehaviour
    {
        public GameObject[] objectsToActivate;
        public GameObject[] objectsToDeactivate;
        public void ConfirmSpawn()
        {
            GameObject arSessionOrigin = GameObject.Find("AR Session Origin");
            ARPlaneManager planeManager = arSessionOrigin.GetComponent<ARPlaneManager>();
            planeManager.requestedDetectionMode = PlaneDetectionMode.None;

            arSessionOrigin.GetComponent<SpawnObjectOnPlane>().enabled = false;
            
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
        }
    }
}
