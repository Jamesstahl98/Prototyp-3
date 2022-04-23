using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindCollider : MonoBehaviour
{
    private float baseDamage;

    public string damageType;

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        baseDamage = player.GetComponent<Shooting>().windDamage;
    }

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
