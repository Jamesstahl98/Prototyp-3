using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaCollider : MonoBehaviour
{
    public float baseDamage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //collision.gameObject.GetComponent<Enemy>().TakeDamage(baseDamage);
        }
    }
}
