using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthCollider : MonoBehaviour
{
    public GameObject plantPrefab;
    public float baseDamage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //collision.gameObject.GetComponent<Enemy>().TakeDamage(baseDamage);
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
