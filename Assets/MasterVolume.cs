using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterVolume : MonoBehaviour{
    public Slider sliderVolume;

    private void Start(){
        sliderVolume.value = Settings.volume;
    }

    public void Update(){
        Settings.volume = sliderVolume.value;
        PlayerPrefs.SetFloat("MusicVolume", Settings.volume);
    }
}
