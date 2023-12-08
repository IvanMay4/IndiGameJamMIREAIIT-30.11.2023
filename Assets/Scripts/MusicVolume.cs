using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour{

    void Update(){
        foreach (AudioSource audioSource in GetComponents<AudioSource>())
            audioSource.volume = Settings.volume;
    }
}
