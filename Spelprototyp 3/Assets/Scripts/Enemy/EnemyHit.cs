using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public float positiveDamageModifier;
    public float negativeDamageModifier;
    public float areaDamageCooldown;
    public float areaDamageTimer = 1;
    public string enemyType;

    [SerializeField]
    private float enemyHP;
    [SerializeField]
    private float hpIncreaseFactor;

    void FixedUpdate()
    {
        areaDamageTimer++;
    }

    void Start()
    {
        enemyHP = Mathf.Round(enemyHP * (1 + (Time.time / hpIncreaseFactor)));
    }
    public void TakeDamage(float baseDamage, string damageType)
    {
        if((damageType == "Fire" && enemyType == "Wind") || (damageType == "Wind" && enemyType == "Earth") || (damageType == "Earth" && enemyType == "Lightning") || (damageType == "Lightning" && enemyType == "Water") || (damageType == "Water" && enemyType == "Fire"))
        {
            enemyHP = enemyHP - (baseDamage * positiveDamageModifier);
        }

        else if ((damageType == "Wind" && enemyType == "Fire") || (damageType == "Earth" && enemyType == "Wind") || (damageType == "Lightning" && enemyType == "Earth") || (damageType == "Water" && enemyType == "Lightning") || (damageType == "Fire" && enemyType == "Water"))
        {
            enemyHP = enemyHP - (baseDamage * negativeDamageModifier);
        }

        else
        {
            enemyHP = enemyHP - baseDamage;
        }

        if (enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
