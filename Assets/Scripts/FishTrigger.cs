using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishTrigger : MonoBehaviour
{
    [SerializeField] Image fishUI;
    [SerializeField] Sprite collectedFishImage;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Freddie")
        {
            FindAnyObjectByType<GameManager>().CollectFish();
            fishUI.sprite = collectedFishImage;
            gameObject.SetActive(false);
        }
    }
}
