using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Sprite enemySprite;
    [SerializeField] private float timeBetweenSpawns = 0.5f;
    [SerializeField] private float spawnRandomFactor = 0.3f;
    [SerializeField] private int enemiesPerWave = 20;
    [SerializeField] private float moveSpeed = 2.0f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public Sprite GetEnemySprite() { return enemySprite; }
    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }
    public float GetSpawnRandomFactor() { return spawnRandomFactor; }
    public int GetEnemiesPerWave() { return enemiesPerWave; }
    public float GetMoveSpeed() { return moveSpeed; }
}
