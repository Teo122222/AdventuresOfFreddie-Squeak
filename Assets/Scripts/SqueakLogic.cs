using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SqueakLogic : PlayerLogic
{
    bool onHole = false;
    GameObject otherHole;
    void OnHole(InputValue v)
    {
        if (onHole)
        {
            transform.position = otherHole.transform.position;
            string roomType = otherHole.GetComponent<HoleTrigger>().GetRoomType();
            SetRoom(roomType);
            if (GameObject.FindWithTag("Freddie").GetComponent<PlayerLogic>().GetRoom() == roomType)
            {
                FindAnyObjectByType<GameManager>().RestartLevel();
            }
            otherHole = gameObject;
        }
    }
    
    public void SetHole(GameObject other)
    {
        otherHole = other;
        onHole = true;
    }

    public void UnSetHole()
    {
        onHole = false;
    }
}
