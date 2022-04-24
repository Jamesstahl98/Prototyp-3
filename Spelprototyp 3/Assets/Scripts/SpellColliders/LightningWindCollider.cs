using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningWindCollider : MonoBehaviour
{
    private float baseDamage;
    public string damageType;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        baseDamage = (player.GetComponent<Shooting>().lightningDamage + player.GetComponent<Shooting>().windDamage) / 1.5f;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var enemyHit = collision.gameObject.GetComponent<EnemyHit>();

            if (enemyHit.areaDamageTimer > enemyHit.areaDamageCooldown)
            {
                enemyHit.TakeDamage(baseDamage, damageType);
                enemyHit.areaDamageTimer = 0;
            }
        }
    }
}
