using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] float keySpeed;
    [SerializeField] float keyDistance;

    GameObject target;
    Vector3 actualPos;
    void Awake()
    {
        target = gameObject;
        actualPos = transform.position;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > keyDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, keySpeed * Time.deltaTime);
            actualPos = transform.position;
        }
        else
        {
            
            transform.position = new Vector3(actualPos.x, actualPos.y + Mathf.Sin(Time.time*8) * 0.1f, actualPos.z);
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
