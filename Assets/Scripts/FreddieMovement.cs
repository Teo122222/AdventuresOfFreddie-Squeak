using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FreddieMovement : Movement
{
    [SerializeField] float jumpVelocity;
    [SerializeField] float coyoteTime;
    [SerializeField] float jumpBufferTime;

    EdgeCollider2D feetCollider;
    float coyoteTimeCounter;
    float jumpBufferCounter;
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
            FreddieJump();
        }
    }

    void FreddieJump()
    {
        if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            coyoteTimeCounter = coyoteTime;

            if (isHolding) jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        jumpBufferCounter -= Time.deltaTime;
        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            playerRigidbody.velocityY = jumpVelocity;
            jumpBufferCounter = 0f;
        }
    }
}