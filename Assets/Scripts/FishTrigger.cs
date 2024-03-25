using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishTrigger : MonoBehaviour
{
    [SerializeField] Image fishUI;
    [SerializeField] Sprite collectedFishImage;
    [SerializeField] AudioClip collectSound;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Freddie" && gameObject.activeSelf)
        {
            FindAnyObjectByType<GameManager>().CollectFish();
            fishUI.sprite = collectedFishImage;
            FindAnyObjectByType<MusicManager>().PlaySoundClip(collectSound, transform, 1f);
            gameObject.SetActive(false);
        }
    }
}
