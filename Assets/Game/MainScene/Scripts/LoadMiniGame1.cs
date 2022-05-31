using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Game.MainScene.Scripts
{
    public class LoadMiniGame1 : MonoBehaviour
    {
        public GameObject feed;
        public GameObject minigame1;
        public void LoadScene()
        {
            Debug.Log("Loading MiniGame1");
            SceneManager.LoadScene("minigame1", LoadSceneMode.Additive);
            feed.SetActive(false);
            minigame1.SetActive(false);
        }
    }
}
