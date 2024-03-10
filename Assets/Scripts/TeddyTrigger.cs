using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Scratch")
        {
            Destroy(gameObject, 0.75f);
        }
    }
}
