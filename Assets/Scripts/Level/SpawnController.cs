using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnController : MonoBehaviour
{

    private const string SPAWN_ENEMY_METHOD = "SpawnOneEnemy";
    [SerializeField] private float spawnInterval = 0.5f;
    [SerializeField] private float spawnDelay = 2.0f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float enemySpeed = 4.0f;

    private SpawnPoint[] spawnPoints;
    private GameObject enemyParent;

    private WaveConfig waveConfig;

    public delegate void EnemySpawned();
    public static event EnemySpawned EnemySpawnedEvent;


    private void Start()
    {
        // get the spawn points
        spawnPoints = GetComponentsInChildren<SpawnPoint>();

        // set up the enemy Parent on the hierarchy
        enemyParent = GameObject.Find("EnemyParent");
        if (!enemyParent)
        {
            enemyParent = new GameObject("EnemyParent");
        }

    }
    //Start spawning enemies
    public void EnableSpawning()
    {
        InvokeRepeating(SPAWN_ENEMY_METHOD, spawnDelay, spawnInterval);
    }
    //Stop spawning enemies
    public void DisableSpawning()
    {
        CancelInvoke(SPAWN_ENEMY_METHOD);
    }

    private void SpawnOneEnemy()
    {
        // Create enemy using pre-determined prefab
        var e = Instantiate(enemyPrefab, enemyParent.transform);
        // Set enemy speed based on config
        e.GetComponent<SpriteRenderer>().sprite = waveConfig.GetEnemySprite();
        e.GetComponent<Enemy>().MoveSpeed = waveConfig.GetMoveSpeed();
        // Choose random spawn point
        int i = Random.Range(0, spawnPoints.Length);
        e.transform.position = spawnPoints[i].transform.position;
        // Enemy velocity
        Rigidbody2D rbb = e.GetComponent<Rigidbody2D>();
        rbb.velocity = Vector2.left * enemySpeed;
        PublishEnemySpawnedEvent();
    }

    public void PublishEnemySpawnedEvent()
    {
        EnemySpawnedEvent?.Invoke();
    }

    // Save config
    public void SetWaveConfig(WaveConfig currentWave)
    {
        this.waveConfig = currentWave;
        this.enemyPrefab = currentWave.GetEnemyPrefab();
        this.spawnInterval = currentWave.GetTimeBetweenSpawns();
    }

}
