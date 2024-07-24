using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int scoreValue;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //Initilize the score to Nothing then the value will be updated from the gamecontroller 
        scoreText.text = "Score:" + scoreValue;
    }
}
