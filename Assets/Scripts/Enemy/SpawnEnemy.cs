using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{   
   [SerializeField] private GameObject[] SpawnPoint;
    [SerializeField] private GameObject trianglePrefab;

    private float enemySpeed = 6.0f;
    [SerializeField]
    private float spawnDelay = 10.0f;
    [SerializeField]
    private float spawnInterval = 3.55f;

    const string oneEnemy = "SpawnOneEnemy";

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWaves();    
    }

    //Used for spawning power UP/DOWNS in an interval
    private void SpawnEnemyWaves()
    {
        InvokeRepeating(oneEnemy, spawnDelay, spawnInterval);
        Invoke("SpawnEnemyWaves", 10f);
    }


    private void SpawnOneEnemy(){

        //Spawn at random spawn point
        int Spawn = UnityEngine.Random.Range(0, SpawnPoint.Length);

        GameObject triangle =
        Instantiate(trianglePrefab);

        // Give it a speed and direction
        triangle.transform.position = SpawnPoint[Spawn].transform.position;
        Rigidbody2D rbb = triangle.GetComponent<Rigidbody2D>();
        rbb.velocity = Vector2.right * enemySpeed;
 

    }
}
