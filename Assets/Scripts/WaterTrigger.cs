using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Freddie")
        {
            FindAnyObjectByType<GameManager>().RestartLevel();
        }
    }

}
