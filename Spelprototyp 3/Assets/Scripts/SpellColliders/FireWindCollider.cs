using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWindCollider : MonoBehaviour
{
    public float baseDamage;

    public string damageType;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var enemyHit = collision.gameObject.GetComponent<EnemyHit>();

            if (enemyHit.areaDamageTimer > enemyHit.areaDamageCooldown)
            {
                Debug.Log("damage");
                enemyHit.TakeDamage(baseDamage, damageType);
                enemyHit.areaDamageTimer = 0;
            }
        }
    }
}
