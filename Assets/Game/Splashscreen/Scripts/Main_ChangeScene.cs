using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_ChangeScene : MonoBehaviour
{

    public bool changeTrigger = false;

    public int changeToSceneID;

    private bool startLoading = false;

    public GameObject refAnchor;

    // Update is called once per frame
    void Update()
    {
        if (!startLoading && changeTrigger)
        {
            startLoading = true;
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
    }
}
