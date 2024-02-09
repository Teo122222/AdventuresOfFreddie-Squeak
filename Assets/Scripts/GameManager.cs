using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Animator fadeAnimation;
    [SerializeField] GameObject Freddie;
    [SerializeField] GameObject Squeak;

    Collider2D freddieCollider;
    Collider2D squeakCollider;
    bool isRestarting = false;
    bool hasKey = false;
    void Start()
    {
        freddieCollider = Freddie.GetComponent<Collider2D>();
        squeakCollider = Squeak.GetComponent<Collider2D>();
    }

    void Update()
    {
        if (freddieCollider.IsTouching(squeakCollider) && !isRestarting)
        {
            RestartLevel();
        }
    }

    public void RestartLevel()
    {
        isRestarting = true;
        StartCoroutine(PlayAnimationAndLoadLevel());
    }

    IEnumerator PlayAnimationAndLoadLevel()
    {
        Squeak.GetComponent<Movement>().Die();
        Freddie.GetComponent<Movement>().Die();
        fadeAnimation.SetTrigger("StartTransistion");
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 

    public void SetHasKey(bool key)
    {
        hasKey = key;
    }

    public bool GetHasKey()
    {
        return hasKey;
    }

}
