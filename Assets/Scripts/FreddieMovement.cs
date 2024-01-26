using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FreddieMovement : Movement
{
    [SerializeField] float jumpVelocity;
    void OnJump(InputValue v)
    {

    }

    override protected void Update()
    {
        base.Update();
        FreddieJump();
    }

    void FreddieJump()
    {
        
    }
}