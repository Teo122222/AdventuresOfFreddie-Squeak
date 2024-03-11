using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreddieLogic : PlayerLogic
{
    [SerializeField] GameObject scratch;
    [SerializeField] Transform spawnPoint;
    void OnScratch()
    {
        if (gameObject.GetComponent<Movement>().IsAlive())
        {
            GameObject newScratch = Instantiate(scratch, spawnPoint.position, transform.rotation);
            newScratch.transform.localScale = transform.localScale;
            if (newScratch.transform.position.x < -10.8 || newScratch.transform.position.x > 10.8)
            {
                Destroy(newScratch);
            }
            else Destroy(newScratch, 0.75f);
        }
    }
}