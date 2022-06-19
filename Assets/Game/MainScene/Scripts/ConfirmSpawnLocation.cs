using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Game.MainScene.Scripts
{
    public class ConfirmSpawnLocation : MonoBehaviour
    {
        public GameObject miniGameButton;
        public GameObject backFromMiniGameButton;
        public GameObject confirmSpawnLocationButton;
        private bool _confirmed;
   
        public GameObject referencePoint;

        public LevelManager levelOrder;
        private int _levelIndex = 0;
        private GameObject _loadedLevel;

        public void ConfirmSpawn()
        {
            if (!_confirmed)
            {
                GameObject arSessionOrigin = GameObject.Find("AR Session Origin");
                ARPlaneManager planeManager = arSessionOrigin.GetComponent<ARPlaneManager>();
                planeManager.requestedDetectionMode = PlaneDetectionMode.None;

                arSessionOrigin.GetComponent<SetReferencePoint>().enabled = false;
            
                foreach (var plane in planeManager.trackables)
                {
                    plane.gameObject.SetActive(false);
                }
                Debug.Log("placing Tamagotchi");
                // Instantiate(tamagotchi, referencePoint.transform);
                miniGameButton.SetActive(true);
                confirmSpawnLocationButton.SetActive(false);
                BuildLevel();
                referencePoint.transform.GetChild(0).gameObject.SetActive(false); // set false so the orange won't be visible in here anymore
                _confirmed = true;
            }
            
        }

        private void BuildLevel()
        {
            Destroy(_loadedLevel);
            _loadedLevel = Instantiate(levelOrder.levelLoadingOrder[_levelIndex], referencePoint.transform);
        }

        public void BuildMiniGame()
        {
            _levelIndex++;
            backFromMiniGameButton.SetActive(true);
            miniGameButton.SetActive(false);
            BuildLevel();
        }  
        
        public void BuildFeedingGame()
        {
            _levelIndex--;
            backFromMiniGameButton.SetActive(false);
            miniGameButton.SetActive(true);
            BuildLevel();
        }
    }
}
