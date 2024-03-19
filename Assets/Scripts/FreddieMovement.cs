using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FreddieMovement : Movement
{
    [SerializeField] float jumpVelocity;
    [SerializeField] float coyoteTime;
    [SerializeField] float jumpBufferTime;

    GameObject currentOneWayPlatform;
    BoxCollider2D playerCollider;
    EdgeCollider2D feetCollider;
    float coyoteTimeCounter;
    float jumpBufferCounter;
    bool isHolding;
    bool hasJumped = false;
    void OnJump(InputValue v)
    {
        if (isAlive)
        {
            if (v.isPressed)
            {
                upButtons.SetActive(false);
                jumpBufferCounter = jumpBufferTime;
                isHolding = true;
            }
            else if (!v.isPressed)
            {
                if (coyoteTimeCounter > 0f)
                {
                    playerRigidbody.velocityY *= 0.5f;
                    coyoteTimeCounter = 0;
                }
                isHolding = false;
                playerAnimator.SetBool("isLanding", true);
            }
        }
    }

    void OnDrop(InputValue v)
    {
        if (isAlive)
        { 
            if (currentOneWayPlatform != null)
            {
                StartCoroutine(DisableCollider());
            }
        } 
    }

    //https://www.youtube.com/watch?v=7rCUt6mqqE8
    IEnumerator DisableCollider()
    {
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        Physics2D.IgnoreCollision(feetCollider, platformCollider);
        yield return new WaitForSeconds(0.7f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
        Physics2D.IgnoreCollision(feetCollider, platformCollider, false);
        
    }

    void Start()
    {
        feetCollider = GetComponent<EdgeCollider2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    override protected void Update()
    {
        base.Update();
        if (isAlive)
        {
            FreddieJump();
            if (playerRigidbody.velocityX < 0)
            {
                movingButtons.transform.localScale = new Vector2(-1f, 1f);
                upButtons.transform.localScale = new Vector2(-1f, 1f);
            }
            else
            {
                movingButtons.transform.localScale = new Vector2(1f, 1f);
                upButtons.transform.localScale = new Vector2(1f, 1f);
            }
        }
    }

    void FreddieJump()
    {
        if ((feetCollider.IsTouchingLayers(LayerMask.GetMask("Landing")) && playerAnimator.GetBool("isJumping")) || playerRigidbody.velocityY < 0)
        {
            playerAnimator.SetBool("isLanding", true);
        }
        if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            coyoteTimeCounter = coyoteTime;
            playerAnimator.SetBool("isJumping", false);
            if (isHolding) jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            playerAnimator.SetBool("isJumping", true);
            coyoteTimeCounter -= Time.deltaTime;
        }
        jumpBufferCounter -= Time.deltaTime;
        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            playerAnimator.SetBool("isLanding", false);
            playerRigidbody.velocityY = jumpVelocity;
            jumpBufferCounter = 0f;
            hasJumped = true;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OneWayPlatform")
        {
            currentOneWayPlatform = collision.gameObject;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OneWayPlatform")
        {
            currentOneWayPlatform = null;
        }
    }

    public bool HasJumped()
    {
        return hasJumped;
    }
}