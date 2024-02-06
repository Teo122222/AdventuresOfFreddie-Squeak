using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    GameObject resident;
    Collider2D residentCollider;
    void Start()
    {
        resident = GameObject.FindWithTag("Resident");
        residentCollider = resident.GetComponent<Collider2D>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Freddie")
        {
            resident.GetComponent<SpriteRenderer>().enabled = true;
            resident.GetComponent<Rigidbody2D>().velocityX = -15;
            StartCoroutine(MoveResident(collision));
        }
    }

    IEnumerator MoveResident(Collider2D playerCollider)
    {
        while (!residentCollider.IsTouching(playerCollider)) yield return null;
        //yield return new WaitForSecondsRealtime(0.5f);
        resident.GetComponent<Rigidbody2D>().velocityX = 0;
        FindAnyObjectByType<GameManager>().RestartLevel();
    }
}
