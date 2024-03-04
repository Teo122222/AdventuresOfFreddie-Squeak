using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheeseTrigger : MonoBehaviour
{
    [SerializeField] Image cheeseUI;
    [SerializeField] Sprite collectedCheeseImage;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Squeak")
        {
            FindAnyObjectByType<GameManager>().CollectCheese();
            cheeseUI.sprite = collectedCheeseImage;
            gameObject.SetActive(false);
        }
    }
}
