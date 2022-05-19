using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;

    public GameObject hpBar;

    private float damagedTimer = 30;
    private SpriteRenderer sr;
    [SerializeField]
    private GameObject deathScreen;
    private ParticleSystem ps;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        ps = gameObject.GetComponent<ParticleSystem>();
    }

    void FixedUpdate()
    {
        damagedTimer++;

        if(damagedTimer == 30)
        {
            sr.color = new Color(255f, 255f, 255f, 255f);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && damagedTimer > 30)
        {
            ps.Play();
            damagedTimer = 0;
            playerHealth = playerHealth - collision.gameObject.GetComponent<Enemy>().damage;
            sr.color = new Color(255f, 0f, 0f, 255f);
            hpBar.GetComponent<HealthBar>().SetHealth(playerHealth);

            if (playerHealth <= 0)
            {
                deathScreen.SetActive(true);
            }
        }
    }
}
