using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Animator fadeAnimation;
    [SerializeField] GameObject Freddie;
    [SerializeField] GameObject Squeak;
    [SerializeField] Image keyUI;
    [SerializeField] Sprite collectedKeyImage;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] GameObject endCanvas;
    [SerializeField] Animator endAnimation;
    [SerializeField] float starTime;
    //[SerializeField] Canvas endCanvas;

    Collider2D freddieCollider;
    Collider2D squeakCollider;
    bool isRestarting = false;
    bool hasKey = false;
    bool isDoorOpened = false;
    bool hasFish = false;
    bool hasCheese = false;

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
        StartCoroutine(PlayAnimationAndLoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator PlayAnimationAndLoadLevel(int index)
    {
        Squeak.GetComponent<Movement>().Die();
        Freddie.GetComponent<Movement>().Die();
        fadeAnimation.SetTrigger("StartTransistion");
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(index);
    }

    public void BackToMainMenu()
    {
        isRestarting = true;
        StartCoroutine(PlayAnimationAndLoadLevel(0));
    }

    public void PauseGame()
    {
        Squeak.GetComponent<Movement>().Die();
        Freddie.GetComponent<Movement>().Die();
        pauseCanvas.SetActive(true);
    }

    public void ResumeGame()
    {
        Squeak.GetComponent<Movement>().UnDie();
        Freddie.GetComponent<Movement>().UnDie();
        pauseCanvas.SetActive(false);
    }

    public void EndGame()
    {
        Squeak.GetComponent<Movement>().Die();
        Freddie.GetComponent<Movement>().Die();
        endCanvas.SetActive(true);
        float animationTime = 0.5f;
        if (hasKey) animationTime += starTime;
        if (hasCheese || hasFish) animationTime += starTime;
        if (hasCheese && hasFish) animationTime += starTime;
        StartCoroutine(PlayEndAnimation(animationTime));
    }

    IEnumerator PlayEndAnimation(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log(time);
        endAnimation.enabled = false;
    }

    public void SetHasKey(bool key)
    {
        hasKey = key;
    }

    public bool GetHasKey()
    {
        return hasKey;
    }

    public void OpenDoor()
    {
        isDoorOpened = true;
        keyUI.sprite = collectedKeyImage;
    }

    public bool isDoorOpen()
    {
        return isDoorOpened;
    }

    public void CollectCheese()
    {
        hasCheese = true;
    }

    public void CollectFish()
    {
        hasFish = true;
    }
}
