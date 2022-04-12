using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthCollider : MonoBehaviour
{
    public GameObject plantPrefab;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //collision.gameObject.GetComponent<Enemy>().TakeDamage(5);
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
