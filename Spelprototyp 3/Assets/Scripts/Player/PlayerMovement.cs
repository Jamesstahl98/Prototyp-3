using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Components
    Rigidbody2D rb;
    Animator animator;

    // Player
    public float walkSpeed = 4f;
    public float speedLimiter = 0.7f;
    float inputHorizontal;
    float inputVertical;

    private SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(walkSpeed));
    }

    void FixedUpdate()
    {
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            if(inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= speedLimiter;
                inputVertical *= speedLimiter;
            }

            rb.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);
            if (inputHorizontal > 0)
            {
                sr.flipX = false;
            }
            else if (inputHorizontal < 0)
            {
                sr.flipX = true;
            }
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }
    }

}
