using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Animator fadeAnimation;
    [SerializeField] GameObject FreddiePrefab;
    [SerializeField] GameObject SqueakPrefab;
    [SerializeField] Transform a;
    [SerializeField] Image keyUI;
    [SerializeField] Sprite collectedKeyImage;
    [SerializeField] Sprite openDoorImage;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] GameObject endCanvas;
    [SerializeField] Animator endAnimation;
    [SerializeField] float starTime;
    [SerializeField] AudioClip startSound;
    //[SerializeField] Canvas endCanvas;

    GameObject Freddie;
    GameObject Squeak;

    Collider2D freddieCollider;
    Collider2D squeakCollider;
    bool isRestarting = false;
    bool hasKey = false;
    bool isDoorOpened = false;
    bool hasFish = false;
    bool hasCheese = false;


    void Start()
    {
        Freddie = PlayerInput.Instantiate(FreddiePrefab, controlScheme: "LeftKeyboard", pairWithDevice: Keyboard.current).gameObject;
        Squeak = PlayerInput.Instantiate(SqueakPrefab, controlScheme: "RightKeyboard", pairWithDevice: Keyboard.current).gameObject;
        freddieCollider = Freddie.GetComponent<Collider2D>();
        squeakCollider = Squeak.GetComponent<Collider2D>();
        FindAnyObjectByType<MusicManager>().PlaySoundClip(startSound, transform, 0.8f);
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
        FindAnyObjectByType<DoorTrigger>().gameObject.GetComponent<SpriteRenderer>().sprite = openDoorImage;
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
