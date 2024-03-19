using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreddieLogic : PlayerLogic
{
    [SerializeField] GameObject scratch;
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject scratchButton;
    void OnScratch()
    {
        if (gameObject.GetComponent<Movement>().IsAlive())
        {
            if (scratchButton.activeSelf)
                FindAnyObjectByType<TeddyTrigger>().SetShowed(true);
            scratchButton.SetActive(false);
            GameObject newScratch = Instantiate(scratch, spawnPoint.position, transform.rotation);
            newScratch.transform.localScale = transform.localScale;
            if (newScratch.transform.position.x < -10.8 || newScratch.transform.position.x > 10.8)
            {
                Destroy(newScratch);
            }
            else Destroy(newScratch, 0.75f);
        }
    }

    void Update()
    {
        if (transform.localScale.x == -1)
        {
            scratchButton.transform.localScale = new Vector2(-1f, 1f);
            Debug.Log("sss");
        }
        else
        {
            scratchButton.transform.localScale = new Vector2(1f, 1f);
        }
    }

    public void ShowScratchControls()
    {
        scratchButton.SetActive(true);
    }

    public void HideScratchControls()
    {
        scratchButton.SetActive(false);
    }
}