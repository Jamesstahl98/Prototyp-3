using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] enemyWaves;

    private int waveNumber = 0;

    public int enemyNumber = 0;

    public int maxEnemies;

    public int waveTime;

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
            var wave = Mathf.RoundToInt(totalTimer / waveTime);
            Debug.Log(wave);
            if(wave <= enemyWaves.Length -1)
            {
                var newEnemy = Instantiate(enemyWaves[wave], spawnPoints[Random.Range(0, spawnPoints.Length)].position, transform.rotation);
            }
            else if (wave == enemyWaves.Length)
            {
                Debug.Log("win");
            }
            timer = 0f;
        }
    }
}