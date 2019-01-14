using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    void Play(AudioClip audioClip)
    {
        this.audioClip = audioClip;
    }
}
