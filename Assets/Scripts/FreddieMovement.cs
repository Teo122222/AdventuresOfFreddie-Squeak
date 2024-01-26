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
    void OnJump(InputValue v)
    {
        if (v.isPressed)
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else if (!v.isPressed && coyoteTimeCounter > 0f)
        {
            playerRigidbody.velocityY *= 0.5f;
            coyoteTimeCounter = 0;
            
        }
    }
    void Start()
    {
        feetCollider = GetComponent<EdgeCollider2D>();
    }

    override protected void Update()
    {
        base.Update();
        FreddieJump();
    }

    void FreddieJump()
    {
        if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            coyoteTimeCounter = coyoteTime;
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