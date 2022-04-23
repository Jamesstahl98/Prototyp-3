using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollider : MonoBehaviour
{
    private float baseDamage;

    public string damageType;

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        baseDamage = player.GetComponent<Shooting>().waterDamage;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHit>().TakeDamage(baseDamage, damageType);
        }
    }
}
