using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{

    [SerializeField] public GameObject firstPlaySelectedButton;
    [SerializeField] public GameObject firstSettingsSelectedButton;

    void Start()
    {
        SetPlayButton();
    }

    public void SetPlayButton()
    {
        // code from gamesplusjames (2021) - reference in report -----
        // clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        // set new selected object
        EventSystem.current.SetSelectedGameObject(firstPlaySelectedButton);
        // ------------------------------------------------------------
    }

    public void SetSettingsButton()
    {
        // code from gamesplusjames (2021) - reference in report -----
        // clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        // set new selected object
        EventSystem.current.SetSelectedGameObject(firstSettingsSelectedButton);
        // ------------------------------------------------------------
    }

}
