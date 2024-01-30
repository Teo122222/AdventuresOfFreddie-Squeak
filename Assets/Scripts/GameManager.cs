using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Animator fadeAnimation;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RestartLevel()
    {
        StartCoroutine(PlayAnimationAndLoadLevel());
    }

    IEnumerator PlayAnimationAndLoadLevel()
    {
        fadeAnimation.SetTrigger("StartTransistion");
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 

}
