using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollider : MonoBehaviour
{
    public GameObject magmaPrefab;

    public float magmaForce = 2f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //collision.gameObject.GetComponent<Enemy>().TakeDamage(5);
        }

        if (collision.gameObject.tag == "Earth")
        {
            MagmaSpawn();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Wind")
        {
            
        }
    }
    void MagmaSpawn()
    {
        GameObject magmaCircle = Instantiate(magmaPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = magmaCircle.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * magmaForce, ForceMode2D.Impulse);
    }
}
