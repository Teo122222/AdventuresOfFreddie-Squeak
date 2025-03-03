using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HomeMenuManager : MonoBehaviour
{
    [SerializeField] Animator fadeAnimation;
    [SerializeField] GameObject homeMenu;
    [SerializeField] GameObject settings;

    MenuManager menuManager;

    private void Awake()
    {
        // if scene is main menu
        if(SceneManager.GetActiveScene().buildIndex==1)
        {
            menuManager = GetComponent<MenuManager>();
        }
    }

    public void StartLevel(int i)
    {
        StartCoroutine(PlayAnimationAndLoadLevel(i));
    }

    IEnumerator PlayAnimationAndLoadLevel(int i)
    {
        fadeAnimation.SetTrigger("StartTransistion");
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(i);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ShowSetting()
    {
        homeMenu.SetActive(false);
        settings.SetActive(true);
        menuManager.SetSettingsButton();
    }

    public void GoBack()
    {
        homeMenu.SetActive(true);
        settings.SetActive(false);
        menuManager.SetPlayButton();
    }
}
