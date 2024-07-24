using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public int life;

    public static LivesSystem instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        life = hearts.Length; // Initialize life based on the number of hearts
    }

    
    //Hearts are either active or inactive on the screen 
    //Issues encountred with destroying them so this was easier
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < life)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }

    //If damage is taken take a heart off the screen and reduce the life count
    public void TakeDamage(int d)
    {
        life -= d;
        life = Mathf.Clamp(life, 0, hearts.Length); // Ensure life stays within the range of 0 to the number of hearts
    }

    //If used it will replenish a heart assuming the player has less than 3
    public void ReplenishLife()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (!hearts[i].activeSelf)
            {
                hearts[i].SetActive(true);
            }
        }

        life = hearts.Length; // Reset life to the number of hearts
    }
}
