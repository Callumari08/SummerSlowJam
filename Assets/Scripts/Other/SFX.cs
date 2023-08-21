using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFX : MonoBehaviour
{
    //ADD RECCURRING AUDIO CLIPS TO THE PREFAB
    //This is to ensure that the audio clips can be used regardless of scene

    /* Reccurring audio clips refers to clips that are used in multiple scenes (ie. buttonSFX) */

    AudioSource src;
    public List<AudioClip> audioClips;

    void Awake()
    {
        src = GetComponent<AudioSource>();
    }

    public void PlayClip(int i)
    {
        src.clip = audioClips[i];
        src.Play();
    }
}
