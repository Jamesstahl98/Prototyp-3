using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCollider : MonoBehaviour
{
    public GameObject lightningWindPrefab;
    public GameObject cloudPrefab;

    public float cloudForce = 3f;
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
            CloudSpawn();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Wind")
        {
            LightningWindSpawn();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void CloudSpawn()
    {
        GameObject cloudCircle = Instantiate(cloudPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = cloudCircle.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * cloudForce, ForceMode2D.Impulse);
    }

    void LightningWindSpawn()
    {
        GameObject lightningWindCone = Instantiate(lightningWindPrefab, transform.position, transform.rotation);
    }
}
