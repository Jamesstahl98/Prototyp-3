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
    [SerializeField]
    private float xpDropRate;
    [SerializeField]
    private GameObject xpPrefab;

    private float hitTimer = 0;
    private SpriteRenderer sr;

    void FixedUpdate()
    {
        areaDamageTimer++;
        hitTimer++;
        if(hitTimer >= 20)
        {
            sr.color = new Color(255f, 255f, 255f, 255f);
        }
    }

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        enemyHP = Mathf.Round(enemyHP * (1 + (Time.time / hpIncreaseFactor)));
    }
    public void TakeDamage(float baseDamage, string damageType)
    {
        sr.color = new Color(255f, 0f, 0f, 255f);
        hitTimer = 0;
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
            var dropNumber = Random.Range(1, 100);
            Debug.Log(dropNumber);
            if (dropNumber <= xpDropRate)
            {
                Instantiate(xpPrefab, gameObject.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
