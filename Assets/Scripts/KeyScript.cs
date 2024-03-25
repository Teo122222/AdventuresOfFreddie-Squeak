using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] float keySpeed;
    [SerializeField] float keyDistance;
    [SerializeField] AudioClip collectSound;

    GameObject target = null;
    void Awake()
    {
        target = gameObject;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time * 8) * 0.003f, transform.position.z);
        if (Vector2.Distance(transform.position, target.transform.position) > keyDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, keySpeed * Time.deltaTime);
            
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Squeak" && target == gameObject)
        {
            target = collision.gameObject;
            FindAnyObjectByType<GameManager>().SetHasKey(true);
            FindAnyObjectByType<MusicManager>().PlaySoundClip(collectSound, transform, 1f);
        }
    }
}
