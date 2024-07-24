using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField]
    private float horizontal_speed = 0.2f;
    [SerializeField]
    private float vertical_speed = 0.2f;

    private Renderer re;

    void Start()
    {
        re = GetComponent<Renderer>();
    }

    // The background is scrolled on screen in a set time 
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * horizontal_speed, Time.time * vertical_speed);
        re.material.mainTextureOffset = offset;
        
    }
}
