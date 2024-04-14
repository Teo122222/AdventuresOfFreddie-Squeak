using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackTrigger : MonoBehaviour
{
    [SerializeField] GameObject fish;
    [SerializeField] GameObject sparkle;
    [SerializeField] Sprite brokenBag;
    [SerializeField] AudioClip tearSound;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Scratch") 
        {
            FindAnyObjectByType<MusicManager>().PlaySoundClip(tearSound, transform, 1f);
            StartCoroutine(BreakObject());
        }
    }

    IEnumerator BreakObject()
    {
        yield return new WaitForSecondsRealtime(0.75f);
        fish.SetActive(true);
        sparkle.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = brokenBag;
        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
    }
}
