using System;
using System.Collections;
using System.Collections.Generic;
//using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{
    [SerializeField] GameObject[] pages;

    public bool hasPlayedBefore = false;

    public static TutorialMenu Instance;

    void Awake()
    {
        if (Instance != null && this.gameObject != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        if (!gameObject.transform.parent)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void OpenTutorial()
    {
        if(!hasPlayedBefore && SceneManager.GetActiveScene().buildIndex == 2)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);            
            GameManager.Instance.PauseGameStart(); 
            hasPlayedBefore = true;
        } 
        else
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }



    public void CallNextPage()
    {
        // Called when tutorial next button is pressed
        for(int i = 0; i < pages.Length; i++)
        {
            
            // if active and is not final
            if(pages[i].activeSelf && i<(pages.Length-1))
            {
                
                pages[i].SetActive(false);
                int nextPage = i+1;
                pages[nextPage].SetActive(true);
                break;
            }
            // else if active and is final
            else if (pages[i].activeSelf && i==(pages.Length-1))
            {
                GameManager.Instance.ResumeGameStart();
                pages[pages.Length-1].SetActive(false); 
                pages[0].SetActive(true); 
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
