using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class SqueakLogic : PlayerLogic
{
    public GameObject border;

    bool onHole = false;
    GameObject otherHole;
    void OnHole(InputValue v)
    {
        if (onHole && gameObject.GetComponent<Movement>().IsAlive())
        {
            transform.position = otherHole.transform.position;
            if (FindAnyObjectByType<GameManager>().GetHasKey())
            {
                FindAnyObjectByType<KeyScript>().gameObject.transform.position = transform.position;
            }
            string roomType = otherHole.GetComponent<HoleTrigger>().GetRoomType();
            GetComponent<Movement>().HideUpControls();
            FindAnyObjectByType<HoleTrigger>().SetShowed(true);
            SetRoom(roomType);
            if (GameObject.FindWithTag("Freddie").GetComponent<PlayerLogic>().GetRoom() == roomType)
            {
                GameObject.FindWithTag("Freddie").GetComponent<PlayerLogic>().ShowExclamation();
                GetComponent<PlayerLogic>().ShowExclamation();
                FindAnyObjectByType<GameManager>().RestartLevel();
            }
            otherHole = gameObject;
            border = GameObject.Find("Border");
            border.SetActive(!border.activeInHierarchy);
            Light2D light = GetComponentInChildren<Light2D>();
            light.enabled = !light.enabled;
            if (Random.Range(0, 100) == 1 && light.enabled)
            {
                light.color = Color.red;
            }
            else
            {
                light.color = Color.white;
            }
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
