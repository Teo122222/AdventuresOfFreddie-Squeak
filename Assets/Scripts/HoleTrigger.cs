using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    [SerializeField] Transform otherHole;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Squeak")
        {
            collision.GetComponent<SqueakLogic>().SetHole(otherHole);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Squeak")
        {
            collision.GetComponent<SqueakLogic>().UnSetHole();
        }
    }
}
