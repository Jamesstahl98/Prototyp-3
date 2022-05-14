using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] enemyWaves;
    public float[] nextWave;

    private int waveNumber = 0;

    public int enemyNumber = 0;

    public int maxEnemies;

    [SerializeField]
    private Transform[] spawnPoints;
    // In seconds
    [SerializeField] private float interval = 2f;
    private float timer = 0f;

    private float totalTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        totalTimer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;
            var newEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, transform.rotation);
        }
    }
}