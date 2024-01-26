using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SqueakMovement : Movement
{
    [SerializeField] float jumpVelocity;
    void OnJump(InputValue v)
    {

    }

    override protected void Update()
    {
        base.Update();
        SqueakJump();
    }

    void SqueakJump()
    {

    }
}
