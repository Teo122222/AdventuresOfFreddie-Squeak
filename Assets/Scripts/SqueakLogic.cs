using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SqueakLogic : PlayerLogic
{
    bool onHole = false;
    Transform otherHole;
    void OnHole(InputValue v)
    {
        if (onHole)
        {
            transform.position = otherHole.position;
        }
    }
    
    public void SetHole(Transform other)
    {
        otherHole = other;
        onHole = true;
    }

    public void UnSetHole()
    {
        onHole = false;
    }
}
