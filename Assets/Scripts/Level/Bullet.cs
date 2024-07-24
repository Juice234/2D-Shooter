using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //Collides with an invisible wall and destroys the bullet, this is done purely for perfomance 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Void2"))
        {
            Destroy(gameObject);
        }
    }
}
