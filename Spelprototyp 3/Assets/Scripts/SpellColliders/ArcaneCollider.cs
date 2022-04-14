using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneCollider : MonoBehaviour
{
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
    }
}