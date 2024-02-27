using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Freddie" || collision.tag == "Squeak")
        {
            collision.GetComponent<PlayerLogic>().SetDoor(true);
            Debug.Log("in");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Freddie" || collision.tag == "Squeak")
        {
            collision.GetComponent<PlayerLogic>().SetDoor(false);
            Debug.Log("out");
        }
    }
}
