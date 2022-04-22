using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;

    private float damagedTimer = 30;
    private SpriteRenderer sr;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
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
            Debug.Log("Player taking damage");
            damagedTimer = 0;
            playerHealth = playerHealth - collision.gameObject.GetComponent<Enemy>().damage;
            sr.color = new Color(255f, 0f, 0f, 255f);

            if (playerHealth <= 0)
            {
                Debug.Log("You died");
            }
        }
    }
}
