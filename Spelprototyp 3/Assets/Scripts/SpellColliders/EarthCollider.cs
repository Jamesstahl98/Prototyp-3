using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthCollider : MonoBehaviour
{
    public GameObject plantPrefab;

    private float baseDamage;
    private int spellHP;

    public string damageType;

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        baseDamage = player.GetComponent<Shooting>().earthDamage;
        spellHP = player.GetComponent<Shooting>().fireHP;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHit>().TakeDamage(baseDamage, damageType);
            spellHP -= 1;

            if (spellHP <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Water")
        {
            PlantSpawn();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void PlantSpawn()
    {
        GameObject plant = Instantiate(plantPrefab, transform.position, Quaternion.identity);
    }
}
