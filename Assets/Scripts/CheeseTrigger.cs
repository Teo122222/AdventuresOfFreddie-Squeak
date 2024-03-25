using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheeseTrigger : MonoBehaviour
{
    [SerializeField] Image cheeseUI;
    [SerializeField] Sprite collectedCheeseImage;
    [SerializeField] AudioClip collectSound;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Squeak" && gameObject.activeSelf)
        {
            FindAnyObjectByType<GameManager>().CollectCheese();
            cheeseUI.sprite = collectedCheeseImage;
            FindAnyObjectByType<MusicManager>().PlaySoundClip(collectSound, transform, 1f);
            gameObject.SetActive(false);
        }
    }
}
