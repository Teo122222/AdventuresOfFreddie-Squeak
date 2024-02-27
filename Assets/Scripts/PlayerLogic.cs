using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] string room;
    bool onDoor = false;

    void OnDoor()
    {
        GameManager manager = FindAnyObjectByType<GameManager>();
        if (onDoor && manager.isDoorOpen() && tag == "Freddie")
        {
            // Only Freddie has to go through the door.
            gameObject.SetActive(false);
            // Game over, display ending ui.
        }
        else if (onDoor && manager.GetHasKey())
        {
            FindAnyObjectByType<KeyScript>().GetComponent<SpriteRenderer>().enabled = false;
            manager.OpenedDoor();
            // Set the UI as the key is open
            // Play door open sound effect
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
