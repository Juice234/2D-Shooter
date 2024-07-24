using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveScript : MonoBehaviour
{
    //Completed on attached video
    public TextMeshProUGUI WaveText;
    public static int waveValue;

    void Start()
    {
        WaveText = GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        //Update wave message based on wave count this is updated via gamecontroller
        if (waveValue < 4)
        {
            WaveText.text = "Wave:" + waveValue;
        }
        else
        {
            WaveText.text = "Objective: Survive !";

        }
    }
}
