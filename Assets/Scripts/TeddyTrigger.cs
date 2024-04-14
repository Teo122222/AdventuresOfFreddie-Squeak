using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyTrigger : MonoBehaviour
{
    [SerializeField] Sprite brokenTeddy;
    [SerializeField] GameObject sparkle;
    [SerializeField] AudioClip tearSound;
    bool showed = false;
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
        sparkle.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = brokenTeddy;
        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Freddie" && !showed)
        {
            collision.gameObject.GetComponent<FreddieLogic>().ShowScratchControls();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Freddie")
        {
            collision.gameObject.GetComponent<FreddieLogic>().HideScratchControls();
        }
    }

    public void SetShowed(bool isShowed)
    {
        showed = isShowed;
    }
}
