using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] string room;
    bool onDoor = false;

    void OnDoor()
    {
        if (gameObject.GetComponent<Movement>().IsAlive())
        {
            GameManager manager = FindAnyObjectByType<GameManager>();
            if (onDoor && manager.isDoorOpen() && tag == "Freddie")
            {
                gameObject.SetActive(false);
                // Game over, display ending ui.
                manager.EndGame();
            }
            else if (onDoor && manager.GetHasKey())
            {
                FindAnyObjectByType<KeyScript>().GetComponent<SpriteRenderer>().enabled = false;
                manager.OpenDoor();
                // Play door open sound effect
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetRoom(string newRoom)
    {
        room = newRoom;
    }
    
    public string GetRoom()
    {
        return room;
    }

    public void SetDoor(bool onD)
    {
        onDoor = onD; 
    }
}
