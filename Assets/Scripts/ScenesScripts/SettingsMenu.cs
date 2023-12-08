using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour{
    [SerializeField] public Slider sliderVolume;
    [SerializeField] public TMP_Text textValueComplexity;

    private void Start(){
        if (!File.Exists(Settings.filenameSaveSettings))
            return;
        sliderVolume.value = Settings.volume;
    }

    private void LateUpdate(){
        Settings.volume = sliderVolume.value;
    }

    public void ExitMain() => Settings.OpenMainMenu();
}
