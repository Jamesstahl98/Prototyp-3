using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MagmaCollider : MonoBehaviour
{
    private float baseDamage;
    private float spellHP;
    public string damageType;
    private GameObject player;
    private ParticleSystem ps;
    private SpriteRenderer sr;
    private BoxCollider2D collider;
    private bool spellDead = false;

    void Start()
    {
        player = GameObject.Find("Player");
        ps = gameObject.GetComponent<ParticleSystem>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        collider = gameObject.GetComponent<BoxCollider2D>();
        baseDamage = (player.GetComponent<Shooting>().earthDamage + player.GetComponent<Shooting>().fireDamage) / 2f;
        spellHP = Mathf.Round((player.GetComponent<Shooting>().fireHP + player.GetComponent<Shooting>().earthHP) / 2f);
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

            if(spellHP <= 0)
            {
                ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                sr.GetComponent<Renderer>().enabled = false;
                GetComponent<Collider>().enabled = false;
                StartCoroutine(PauseCode());
            }
        }
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
