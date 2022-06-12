using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int counter = 0; 
    void Update()
    {
        scoreText.text = "Score: " + counter;
        
    }
}
