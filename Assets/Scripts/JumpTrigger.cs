using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Freddie")
        {
            FreddieMovement movement = collision.gameObject.GetComponent<FreddieMovement>();
            if (!movement.HasJumped())
                movement.ShowUpControls();
        }
    }
}
