using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private float horizontal;
    private float speed = 8f;
    private float jumpingpower = 16f;
    private bool isFacingRight = true;
    private bool isDashing = false;
    private float timeToDash = 0.5f;
    private float time = 0f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask groundlayer;



    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            time += Time.deltaTime;
            if (time > timeToDash)
            {
                time = 0;
                isDashing = false;
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
            Dash();
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsOnGround())
            rb.velocity = new Vector2(rb.velocity.x, jumpingpower);

        if (Input.GetButtonDown("Jump") && IsOnWall()) 
            rb.velocity = new Vector2(horizontal * speed, jumpingpower);

        Flip();
    }
    private void Dash()
    {
        isDashing = true;
    }
    private void FixedUpdate()
    {
        if(isDashing) rb.velocity = new Vector2(horizontal * speed * 3, 0);
        else rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if(isFacingRight && horizontal <0f||!isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *=-1f;
            transform.localScale = localScale;
        }
    }

    private bool IsOnGround()
    {
        return Physics2D.OverlapBox(groundCheck.position,groundCheck.transform.localScale,0f,groundlayer);
    }

    private bool IsOnWall()
    {
        return Physics2D.OverlapBox(wallCheck.position, wallCheck.transform.localScale, 0f, groundlayer);
    }
}
