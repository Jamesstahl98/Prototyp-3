using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FireCollider : MonoBehaviour
{
    public GameObject magmaPrefab;
    public GameObject fireTornadoPrefab;

    public float magmaForce = 2f;
    private float baseDamage;
    private int spellHP;
    private bool spellDead = false;

    public string damageType;

    private GameObject player;
    private ParticleSystem ps;
    private SpriteRenderer sr;
    private BoxCollider2D collider;

    void Start()
    {
        player = GameObject.Find("Player");
        ps = gameObject.GetComponent<ParticleSystem>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        collider = gameObject.GetComponent<BoxCollider2D>();
        baseDamage = player.GetComponent<Shooting>().fireDamage;
        spellHP = player.GetComponent<Shooting>().fireHP;
    }

    void FixedUpdate()
    {
        if (spellDead == true && gameObject.GetComponent<Light2D>().intensity >= 0)
        {
            Debug.Log("spell dead");
            gameObject.GetComponent<Light2D>().intensity = gameObject.GetComponent<Light2D>().intensity - 0.02f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHit>().TakeDamage(baseDamage, damageType);
            spellHP -= 1;

            if (spellHP <= 0)
            {
                ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                sr.GetComponent<Renderer>().enabled = false;
                collider.enabled = false;
                StartCoroutine(PauseCode());
            }
        }

        if (collision.gameObject.tag == "Earth")
        {
            MagmaSpawn();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Wind")
        {
            FireTornadoSpawn();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void MagmaSpawn()
    {
        GameObject magmaCircle = Instantiate(magmaPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = magmaCircle.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * magmaForce, ForceMode2D.Impulse);
    }

    void FireTornadoSpawn()
    {
        GameObject fireCircle = Instantiate(fireTornadoPrefab, transform.position, transform.rotation);
    }

    IEnumerator PauseCode()
    {
        ReduceIntensity();
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    void ReduceIntensity()
    {
        spellDead = true;
    }
}
