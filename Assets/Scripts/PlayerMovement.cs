using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horiontal;
    private float speed = 6.5f;
    private float jumpingPower = 8f;
    private bool isFacingRight = true;

    private bool canDash = true;
    private int rorl;
    private bool isDashing;
    private float dashingPower = 10f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask player;
    [SerializeField] private LayerMask enemy;
    [SerializeField] private Animator anim;
    [SerializeField] private TrailRenderer tr;

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        horiontal = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            anim.SetTrigger("takeOf");
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            Debug.Log("its jumping");
        }

        if (isGrounded() || isAboveEnemy())
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (horiontal > 0f)
        {
            anim.SetBool("running", true);
        }
        else if (horiontal < 0f)
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(Dash());
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(horiontal * speed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool isAboveEnemy()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, enemy);
    }

    private void Flip()
    {
        if (isFacingRight && horiontal < 0f || !isFacingRight && horiontal > 0f)
        {
            isFacingRight = !isFacingRight;

            transform.Rotate(0f, 180f, 0f);
        }
    }

    private IEnumerator Dash()
    {
        if (isFacingRight)
        {
            rorl = 1;
        }
        else
        {
            rorl = -1;
        }
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(rorl * dashingPower, 0f);
        tr.emitting = true;
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        Physics2D.IgnoreLayerCollision(6, 7, false);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
