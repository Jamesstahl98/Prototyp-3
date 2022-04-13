using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollider : MonoBehaviour
{
    public GameObject magmaPrefab;
    public GameObject fireTornadoPrefab;

    public float magmaForce = 2f;
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

        if (collision.gameObject.tag == "Earth")
        {
            MagmaSpawn();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Wind")
        {
            FireTornadoSpawn();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void MagmaSpawn()
    {
        GameObject magmaCircle = Instantiate(magmaPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = magmaCircle.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * magmaForce, ForceMode2D.Impulse);
    }

    void FireTornadoSpawn()
    {
        GameObject fireCircle = Instantiate(fireTornadoPrefab, transform.position, transform.rotation);
    }
}
