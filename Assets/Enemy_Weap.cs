using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy_Weap : MonoBehaviour
{
    //Completed on attached video
    private Coroutine firingCoroutine;

    [SerializeField]
    private float bulletSpeed = 200f;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float fireDelay = 2f;

    private SpriteRenderer mySprite;
    private float lastFireTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        if (mySprite == null)
        {
            mySprite = gameObject.AddComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastFireTime + fireDelay)
        {
            // Fire the bullet and update lastFireTime
            Fire();
            lastFireTime = Time.time;
        }
    }

    private void Fire()
    {
        // Instantiate bullet, set velocity and position depending on the player's sprite flipX value
        GameObject Enemy_Bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rbb = Enemy_Bullet.GetComponent<Rigidbody2D>();


        Enemy_Bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        Enemy_Bullet.transform.position = transform.position + new Vector3(1, 0);
            rbb.velocity = Vector2.left * bulletSpeed;
        

    }
}
