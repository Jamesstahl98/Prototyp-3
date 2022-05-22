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

    private float damageTaken;
    private bool isWeak = false;
    private bool isStrong = false;

    [SerializeField]
    private Transform pfDamagePopup;

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
    private ParticleSystem ps;
    private CapsuleCollider2D capsuleCollider;
    private EdgeCollider2D edgeCollider;

    [SerializeField]
    private GameObject enemyDeathSound;
    [SerializeField]
    private GameObject enemyHitSound;

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
        if (gameObject.GetComponent<CapsuleCollider2D>() != null)
        {
            capsuleCollider = gameObject.GetComponent<CapsuleCollider2D>();
        }
        if (gameObject.GetComponent<EdgeCollider2D>() != null)
        {
            edgeCollider = gameObject.GetComponent<EdgeCollider2D>();
        }
        if (gameObject.GetComponent<ParticleSystem>() != null)
        {
            ps = gameObject.GetComponent<ParticleSystem>();
        }

    }
    public void TakeDamage(float baseDamage, string damageType)
    {
        sr.color = new Color(255f, 0f, 0f, 255f);
        hitTimer = 0;
        if((damageType == "Fire" && enemyType == "Wind") || (damageType == "Wind" && enemyType == "Earth") || (damageType == "Earth" && enemyType == "Lightning") || (damageType == "Lightning" && enemyType == "Water") || (damageType == "Water" && enemyType == "Fire"))
        {
            isStrong = true;
            isWeak = false;
            damageTaken = baseDamage * positiveDamageModifier;
            enemyHP = enemyHP - damageTaken;
        }

        else if ((damageType == "Wind" && enemyType == "Fire") || (damageType == "Earth" && enemyType == "Wind") || (damageType == "Lightning" && enemyType == "Earth") || (damageType == "Water" && enemyType == "Lightning") || (damageType == "Fire" && enemyType == "Water"))
        {
            isWeak = true;
            isStrong = false;
            damageTaken = baseDamage * negativeDamageModifier;
            enemyHP = enemyHP - damageTaken;
        }

        else
        {
            isWeak = false;
            isStrong = false;
            damageTaken = baseDamage;
            enemyHP = enemyHP - damageTaken;
        }

        Instantiate(enemyHitSound, gameObject.transform.position, Quaternion.identity);
        //Spawn Damage Popup
        DamagePopup.Create(transform.position, Mathf.Round(damageTaken), isWeak, isStrong);

        if (enemyHP <= 0)
        {
            Instantiate(enemyDeathSound, gameObject.transform.position, Quaternion.identity);
            var dropNumber = Random.Range(1, 100);

            if (dropNumber <= xpDropRate)
            {
                Instantiate(xpPrefab, gameObject.transform.position, Quaternion.identity);
            }

            sr.enabled = false;

            if (gameObject.GetComponent<ParticleSystem>() != null)
            {
                ps.Play();
            }
            if (gameObject.GetComponent<CapsuleCollider2D>() != null)
            {
                capsuleCollider.enabled = false;
            }
            if (gameObject.GetComponent<EdgeCollider2D>() != null)
            {
                edgeCollider.enabled = false;
            }
            GameObject.Find("Spawner").GetComponent<EnemySpawner>().enemyNumber--;
            StartCoroutine(PauseCode());
        }
    }

    IEnumerator PauseCode()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
