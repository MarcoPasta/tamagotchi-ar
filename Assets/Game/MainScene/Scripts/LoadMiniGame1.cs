using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Game.MainScene.Scripts
{
    public class LoadMiniGame1 : MonoBehaviour
    {
        public GameObject feed;
        public GameObject minigame1;
        public GameObject canvas;
        public GameObject tamagotchi;

        public void LoadScene()
        {
            Debug.Log("Loading MiniGame1");
            Destroy(tamagotchi);
            SceneManager.LoadScene("minigame1", LoadSceneMode.Additive);
            feed.SetActive(false);
            minigame1.SetActive(false);
            canvas.SetActive(false);
        }
    }
}
