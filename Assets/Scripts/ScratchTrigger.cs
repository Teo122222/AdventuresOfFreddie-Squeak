using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScratchTrigger : MonoBehaviour
{
    GameObject fish;
    void Awake()
    {
        fish = GetComponent<FishTrigger>().gameObject.GameObject();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("aa");
        if (collision.gameObject.tag == "Teddy")
        {
            Destroy(collision.gameObject, 0.75f);
        }
        else if (collision.gameObject.tag == "Backpack")
        {
            //fish.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("aaa");
        if (collision.tag == "Teddy")
        {
            Destroy(collision.gameObject, 0.75f);
        }
        else if (collision.tag == "Backpack")
        {
            fish.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
