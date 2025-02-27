using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class LanguageSelector : MonoBehaviour
{
    // en - english, ar - arabic, zh - chinese, fr - french, de - german, it - italian, ja - japanese, no - norwegian, fa - farsi, es - spanish, tr - turkish
    public enum AllLanguages {en, ar, zh, fr, de, it, ja, no, fa, es, tr};
    [SerializeField] private AllLanguages buttonLanguage = AllLanguages.en;

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
            default:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
                break;
        }
    }
}
