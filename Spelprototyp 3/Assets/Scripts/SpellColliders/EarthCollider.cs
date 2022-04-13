using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthCollider : MonoBehaviour
{
    public GameObject plantPrefab;

    public float baseDamage;
    public float spellHP;

    public string damageType;

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
