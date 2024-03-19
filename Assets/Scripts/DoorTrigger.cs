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
            if ((FindAnyObjectByType<GameManager>().GetHasKey() && collision.tag == "Squeak" && !FindAnyObjectByType<GameManager>().isDoorOpen()) || (FindAnyObjectByType<GameManager>().isDoorOpen() && collision.tag == "Freddie"))
            {
                collision.gameObject.GetComponent<Movement>().ShowUpControls();
            }
            Debug.Log("in");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Freddie" || collision.tag == "Squeak")
        {
            collision.GetComponent<PlayerLogic>().SetDoor(false);
            collision.gameObject.GetComponent<Movement>().HideUpControls();
            Debug.Log("out");
        }
    }
}
