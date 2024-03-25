using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] string room;
    [SerializeField] GameObject exclamation;
    [SerializeField] AudioClip alertSound;
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
                GetComponent<Movement>().HideUpControls();
                // Play door open sound effect
            }
        }
    }

    public void ShowExclamation()
    {
        if (!exclamation.activeSelf)
        {
            exclamation.SetActive(true);
            FindAnyObjectByType<MusicManager>().PlaySoundClip(alertSound, transform, 1f);
        }
    }

    public void HideExclamation()
    {
        exclamation.SetActive(false);
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
