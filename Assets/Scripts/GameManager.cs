using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Animator fadeAnimation;
    [SerializeField] Movement Freddie;
    [SerializeField] Movement Squeak;
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
        Squeak.Die();
        Freddie.Die();
        fadeAnimation.SetTrigger("StartTransistion");
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 

}
