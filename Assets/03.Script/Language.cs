using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
public class Language : MonoBehaviour
{

    private void Start()
    {
        UserLocalization(0);
    }
    public void UserLocalization(int index)
    {
        LocalizationSettings.SelectedLocale  =
            LocalizationSettings.AvailableLocales.Locales[index];
    }
}
