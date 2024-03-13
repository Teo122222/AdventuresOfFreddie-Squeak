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
            if (GameObject.FindWithTag("Freddie").GetComponent<PlayerLogic>().GetRoom() == otherHole.GetComponent<HoleTrigger>().GetRoomType())
            {
                GameObject.FindWithTag("Freddie").GetComponent<PlayerLogic>().ShowExclamation();
                collision.GetComponent<PlayerLogic>().ShowExclamation();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Squeak")
        {
            collision.GetComponent<SqueakLogic>().UnSetHole();
            GameObject.FindWithTag("Freddie").GetComponent<PlayerLogic>().HideExclamation();
            collision.GetComponent<PlayerLogic>().HideExclamation();
        }
    }

    public string GetRoomType()
    {
        return roomType;
    }
}
