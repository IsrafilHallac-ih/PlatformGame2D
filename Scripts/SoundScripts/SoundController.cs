using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance; // ses kontrol
    public AudioSource[] audioSources;   //ses efect

    private void Awake()
    {
        instance = this;
    }

    public void SoundEffects(int whatSound)
    {
        audioSources[whatSound].Stop();
        audioSources[whatSound].Play();
    }
    public void MixSoundEffects(int whatSound)
    {
        audioSources[whatSound].Stop();
        audioSources[whatSound].pitch = Random.Range(0.8f, 1.3f);
        audioSources[whatSound].Play();
    }
}
