using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantProjectileCollider : MonoBehaviour
{
    private float baseDamage;
    private float spellHP;
    public string damageType;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        baseDamage = (player.GetComponent<Shooting>().earthDamage + player.GetComponent<Shooting>().waterDamage) / 2;
        spellHP = Mathf.Round((player.GetComponent<Shooting>().earthHP + player.GetComponent<Shooting>().waterHP) / 2);
    }

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
