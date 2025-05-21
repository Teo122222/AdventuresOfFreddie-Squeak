using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LanguageSelector : MonoBehaviour
{
    // en - english, ar - arabic, zh - chinese, fr - french, de - german, it - italian, ja - japanese, no - norwegian, fa - farsi, es - spanish, tr - turkish, pl - polish
    public enum AllLanguages {en, ar, zh, fr, de, it, ja, no, fa, es, tr, pl};
    [SerializeField] private AllLanguages buttonLanguage = AllLanguages.en;
    [SerializeField] private TMP_Dropdown dropDown;
    private string[] LocationOfLanguages = {"en","ar","zh","fr", "de", "it", "ja", "no", "fa", "es", "tr", "pl"};

    void Start()
    {
        // if has dropdown
        if(dropDown == null) return;
        
        for (int i = 0; i < LocationOfLanguages.Length; i++)
        {
            string currentLocaleIdentifier = LocalizationSettings.SelectedLocale.Identifier.Code;

            if(currentLocaleIdentifier.ToString() == LocationOfLanguages[i].ToString())
            {
                dropDown.value = i;
                dropDown.RefreshShownValue();
                break;
            }
        }
    }

    public void SetLanguage()
    {
        switch(buttonLanguage)
        {
            case AllLanguages.en:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
                break;
            case AllLanguages.ar:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
                break;
            case AllLanguages.zh:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[2];
                break;
            case AllLanguages.fr:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[3];
                break;
            case AllLanguages.de:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[4];
                break;
            case AllLanguages.it:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[5];
                break;
            case AllLanguages.ja:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[6];
                break;
            case AllLanguages.no:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[7];
                break;
            case AllLanguages.fa:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[8];
                break;
            case AllLanguages.es:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[9];
                break;
            case AllLanguages.tr:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[10];
                break;
            case AllLanguages.pl:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[11];
                break;
            default:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
                break;
        }
    }

    public void DropDownChangeLanguage(int val)
    {
        switch (val)
        {
            case 0:
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
                break;
            case 1:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
                break;
            case 2:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[2];
                break;
            case 3:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[3];
                break;
            case 4:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[4];
                break;
            case 5:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[5];
                break;
            case 6:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[6];
                break;
            case 7:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[7];
                break;
            case 8:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[8];
                break;
            case 9:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[9];
                break;
            case 10:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[10];
                break;
            case 11:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[11];
                break;
            default:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
                break;
        }
    }
}
