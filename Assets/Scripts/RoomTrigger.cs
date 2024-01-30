using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] string roomType;

    bool isRestarting;
    int shouldCheck = 0;

    void Awake()
    {
        isRestarting = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        shouldCheck++;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        HandleTrigger(collision);
        shouldCheck--;
    }

    void HandleTrigger(Collider2D collision)
    {
        if (!isRestarting && shouldCheck % 2 == 0)
        {
            PlayerLogic player = collision.gameObject.GetComponent<PlayerLogic>();
            if (player.GetRoom() != roomType)
            {
                player.SetRoom(roomType);
                if ((collision.tag == "Freddie" && GameObject.FindWithTag("Squeak").GetComponent<PlayerLogic>().GetRoom() == roomType)
                    || (collision.tag == "Squeak" && GameObject.FindWithTag("Freddie").GetComponent<PlayerLogic>().GetRoom() == roomType))
                {
                    FindAnyObjectByType<GameManager>().RestartLevel();
                    isRestarting = true;
                }
            }
        }
    }
}
