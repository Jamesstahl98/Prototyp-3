using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;

    void Start()
    {
        GameObject.Find("Spawner").GetComponent<EnemySpawner>().enemyNumber++;
    }
}
