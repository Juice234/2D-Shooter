using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapons : MonoBehaviour
{
    private Coroutine firingCoroutine;

    [SerializeField]
    private float bulletSpeed = 20f;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float fireDelay = 2f;

    [SerializeField]
    private AudioClip fireSound;

    private AudioSource audioSource;

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

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
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
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();
        if (mySprite.flipX)
        {
            bullet.transform.position = transform.position + new Vector3(-1, 0);
            rbb.velocity = Vector2.left * bulletSpeed;
        }
        else
        {
            bullet.transform.position = transform.position + new Vector3(1, 0);
            rbb.velocity = Vector2.right * bulletSpeed;
        }

        // Play fire sound
        // Sound has a fixed sound volume
        audioSource.volume = 0.1f;
        audioSource.PlayOneShot(fireSound);
    }


}
