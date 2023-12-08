using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource audioPlay;
    

    public void PlaySoundEffect()
    {
        audioPlay.Play();
    }
    
}
