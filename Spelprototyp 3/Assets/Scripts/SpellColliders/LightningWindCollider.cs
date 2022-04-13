using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningWindCollider : MonoBehaviour
{
    public float baseDamage;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //collision.gameObject.GetComponent<Enemy>().TakeDamage(baseDamage);
        }
    }
}
