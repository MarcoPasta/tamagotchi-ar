using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.MainScene.Script
{
    public class MainScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            string identifier = SystemInfo.deviceModel;

            if (!identifier.StartsWith("iPhone"))
            {
                return;
            }
        
            findWebCams();

            Application.RequestUserAuthorization(UserAuthorization.WebCam);
            Debug.Log(Application.HasUserAuthorization(UserAuthorization.WebCam)
                ? "Cam loaded successfully"
                : "Cam loading failed");
        }
    
        /// <summary>
        /// Iterates through each cam of the device and prints device names as log messages
        /// </summary>
        void findWebCams() // 
        {
            foreach (var devices in WebCamTexture.devices)
            {
                Debug.Log("Name: " + devices.name);
            }
        }
    }   
}
