using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Squeak : Movement
{
    [SerializeField] float jumpVelocity;
    [SerializeField] float jumpBufferTime;
    [SerializeField] float jumpTime;

    EdgeCollider2D feetCollider;
    float jumpBufferCounter;
    float jumpTimeCounter;
    bool isHolding;
    void OnJump(InputValue v)
    {
        if (v.isPressed)
        {
            jumpBufferCounter = jumpBufferTime;
            isHolding = true;
        }
        else if (!v.isPressed)
        {
            isHolding = false;
        }
    }
    void Start()
    {
        feetCollider = GetComponent<EdgeCollider2D>();
    }

    override protected void Update()
    {
        base.Update();
        SqueakJump();
    }

    void SqueakJump()
    {
        if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (jumpBufferCounter > 0f)
            {
                playerRigidbody.velocityY = jumpVelocity;
                jumpBufferCounter = 0f;
                jumpTimeCounter = jumpTime;
            }
            if (isHolding) jumpBufferCounter = jumpBufferTime;
            
        }
        jumpBufferCounter -= Time.deltaTime;
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