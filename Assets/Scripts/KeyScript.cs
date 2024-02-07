using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] float keySpeed;
    [SerializeField] float keyDistance;

    GameObject target;
    // Start is called before the first frame update
    void Awake()
    {
        target = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > keyDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, keySpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Freddie" || collision.tag == "Squeak")
        {
            target = collision.gameObject;
        }
    }
}
