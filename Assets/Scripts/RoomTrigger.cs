using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] string roomType;
    [SerializeField] Collider2D closeCollider;

    bool isRestarting;
    bool shouldCheck;

    void Awake()
    {
        isRestarting = false;
        shouldCheck = false;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        HandleTrigger(collision);
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.IsTouching(closeCollider))
        {
            shouldCheck = false;
        }
        else
        {
            shouldCheck = true;
        }
    }

    void HandleTrigger(Collider2D collision)
    {
        if (!isRestarting && shouldCheck && (collision.tag == "Freddie" || collision.tag == "Squeak"))
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
