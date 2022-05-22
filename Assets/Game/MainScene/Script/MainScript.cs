using UnityEngine;

namespace Game.MainScene.Script
{
    public class MainScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var identifier = SystemInfo.deviceModel;
    
            if (!identifier.StartsWith("iPhone")) return;
            findWebCams();
    
            Application.RequestUserAuthorization(UserAuthorization.WebCam); // Request for permission
            if (Application.HasUserAuthorization(UserAuthorization.WebCam)) // check returned permission status
            {
                Debug.Log("Cam loaded successfully");
            }
            else
            {
                Debug.Log("Cam loading failed");
            }
        }
    
        void findWebCams() // iterate through each cam of the device and print names as log messages
        {
            foreach (var devices in WebCamTexture.devices)
            {
                Debug.Log("Name: " + devices.name);
            }
        }


        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
