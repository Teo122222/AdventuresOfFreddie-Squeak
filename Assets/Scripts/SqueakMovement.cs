using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Squeak : Movement
{
    [SerializeField] float jumpVelocity;
    [SerializeField] float coyoteTime;
    [SerializeField] float jumpBufferTime;
    [SerializeField] float jumpTime;

    EdgeCollider2D feetCollider;
    float coyoteTimeCounter;
    float jumpBufferCounter;
    float jumpTimeCounter;
    bool isHolding;
    void OnJump(InputValue v)
    {
        if (isAlive)
        {
            if (v.isPressed)
            {
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
            }
        }
    }
    void Start()
    {
        feetCollider = GetComponent<EdgeCollider2D>();
    }

    override protected void Update()
    {
        base.Update();
        if (isAlive)
        {
            SqueakJump();
        }
    }

    void SqueakJump()
    {
        if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            coyoteTimeCounter = coyoteTime;
            if (isHolding) jumpBufferCounter = jumpBufferTime;
            
        }
        else
        {
            playerAnimator.SetBool("isWalking", true);
            coyoteTimeCounter -= Time.deltaTime;
        }
        jumpBufferCounter -= Time.deltaTime;
        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            playerRigidbody.velocityY = jumpVelocity;
            jumpBufferCounter = 0f;
            jumpTimeCounter = jumpTime;
        }
        if (jumpTimeCounter < 0)
        {
            playerRigidbody.velocityY *= 0.5f;
            jumpTimeCounter = 0f;
        }
        else if (jumpTimeCounter > 0)
        {
            jumpTimeCounter -= Time.deltaTime;
        }
    }
}