using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.MiniGames.Scripts
{
    public class LoadMainscene : MonoBehaviour
    {
        public void LoadScene()
        {
            Debug.Log("Loading MainScene");
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
    }
}
