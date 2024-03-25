using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenuManager : MonoBehaviour
{
    [SerializeField] Animator fadeAnimation;
    [SerializeField] GameObject homeMenu;
    [SerializeField] GameObject settings;
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
    }

    public void GoBack()
    {
        homeMenu.SetActive(true);
        settings.SetActive(false);
    }
}
