using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyTrigger : MonoBehaviour
{
    [SerializeField] Sprite brokenTeddy;
    [SerializeField] GameObject sparkle;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Scratch")
        {
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
}
