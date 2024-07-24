using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    private int playerScore = 0;
    private int waveNumber = 0;
    public static GameController instance = null;

    [SerializeField] private List<WaveConfig> waveConfigList;
    private WaveConfig currentWaveConfig;

    private int enemiesLeftCount;

    private AudioClip waveReadySound;

    //Make sure the object is not destroyed on scene load
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }




    
    private void OnEnable()
    {
        Enemy.EnemyKilledEvent += GCEnemyHandleEnemyDeath;  
        SpawnController.EnemySpawnedEvent += SpawnController_EnemySpawnedEvent;
    }

    private void OnDisable()
    {
        Enemy.EnemyKilledEvent -= GCEnemyHandleEnemyDeath;
        SpawnController.EnemySpawnedEvent -= SpawnController_EnemySpawnedEvent;
    }

    private void SpawnController_EnemySpawnedEvent()
    {
        enemiesLeftCount--;
     
        if(enemiesLeftCount == 0)
        {
            DisableSpawning();

            if(waveNumber < waveConfigList.Count)
            {
                currentWaveConfig = waveConfigList[waveNumber];

                StartCoroutine(SetUpNextWave(currentWaveConfig));

            }
        }
    }

    // Update player score and do so on screen as well
    private void GCEnemyHandleEnemyDeath(Enemy e)
    {
        playerScore += e.ScoreValue;
        ScoreScript.scoreValue = playerScore;
    }

    void Start()
    {
        // set up the wave config files.
        currentWaveConfig = waveConfigList[waveNumber];
        StartCoroutine(SetUpNextWave(currentWaveConfig));
    }

    private IEnumerator SetUpNextWave(WaveConfig currentWave)
    {
        yield return new WaitForSeconds(4.0f);
        // play a sound for the user - get the sound controller, call the method
        enemiesLeftCount = currentWave.GetEnemiesPerWave();
        FindObjectOfType<SpawnController>().SetWaveConfig(currentWave);
        waveNumber++;  
        WaveScript.waveValue = waveNumber; //Uppdate the wave count on screen
        EnableSpawning();

    }

    private void EnableSpawning()
    {
        // get all spawn controllers and kick off the spawn method.
        FindObjectOfType<SpawnController>().EnableSpawning();
    }

    private void DisableSpawning()
    {
        FindObjectOfType<SpawnController>().DisableSpawning();
    }

}
