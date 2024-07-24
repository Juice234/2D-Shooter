using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Proj : MonoBehaviour
{
    // I dont think this does anything any more but i wont be the one to delete it and find out its attached to something 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Void"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            LivesSystem livesSystem = FindObjectOfType<LivesSystem>();
            if (livesSystem != null)
            {
                livesSystem.TakeDamage(1);
                if (livesSystem.life <= 0)
                {
                    //SceneManager.LoadSceneAsync(1);
                    Destroy(GameController.instance.gameObject);
                    Destroy(livesSystem.gameObject);
                }
            }
            Destroy(gameObject);
        }
    }
}
