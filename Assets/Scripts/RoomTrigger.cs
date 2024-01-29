using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] string roomType;
    void OnTriggerEnter2D(Collider2D collision)
    {
        HandleTrigger(collision);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        HandleTrigger(collision);
    }

    void HandleTrigger(Collider2D collision)
    {
        PlayerLogic player = collision.gameObject.GetComponent<PlayerLogic>();
        if (player.GetRoom() != roomType)
        {
            player.SetRoom(roomType);
            if ((collision.gameObject.tag == "Freddie" && GameObject.FindWithTag("Squeak").GetComponent<PlayerLogic>().GetRoom() == roomType)
                || (collision.gameObject.tag == "Squeak" && GameObject.FindWithTag("Freddie").GetComponent<PlayerLogic>().GetRoom() == roomType))
            {
                Debug.Log("Dead!!!");
            }
        }
    }
}
