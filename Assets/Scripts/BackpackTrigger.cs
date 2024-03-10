using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackTrigger : MonoBehaviour
{
    [SerializeField] GameObject fish;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Scratch") 
        {
            fish.SetActive(true);
            Destroy(gameObject);
        }
    }
}
