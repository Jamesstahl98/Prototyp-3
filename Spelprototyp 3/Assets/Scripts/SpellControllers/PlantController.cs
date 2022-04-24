using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public GameObject player;
    public float projectileForce;
    private float spellCD;
    private float size;
    private float spellTimer = 2f;
    private float spellDuration;
    private float startTime;
    private float plantTimer;

    void Start()
    {
        player = GameObject.Find("Player");
        startTime = Time.time;
        spellCD = (player.GetComponent<Shooting>().earthCD + player.GetComponent<Shooting>().waterCD) / 4f;
        spellDuration = (player.GetComponent<Shooting>().earthDuration + (player.GetComponent<Shooting>().waterDuration * 5f));
    }

    void Update()
    {
        spellTimer += Time.deltaTime;
        if(spellTimer >= spellCD)
        {
            FireAtClosestEnemy();
        }

        plantTimer = Time.time - startTime;

        if (plantTimer >= spellDuration)
        {
            Destroy(gameObject);
        }
    }

    void FireAtClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();
        if (allEnemies.Length > 0)
        {
            foreach (Enemy currentEnemy in allEnemies)
            {
                float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
                if (distanceToEnemy < distanceToClosestEnemy)
                {
                    distanceToClosestEnemy = distanceToEnemy;
                    closestEnemy = currentEnemy;
                }
            }
            if (transform.position.x > closestEnemy.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.AddForce((closestEnemy.transform.position - transform.position) * projectileForce, ForceMode2D.Impulse);
            spellTimer = 0;
        }
    }
}
