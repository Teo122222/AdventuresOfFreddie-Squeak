using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    [SerializeField] GameObject otherHole;
    [SerializeField] string roomType;

    void OnTriggerStay2D(Collider2D collision)
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

    public string GetRoomType()
    {
        return roomType;
    }
}
