using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : BaseSingletonMono<SoundController>
{
    AudioSource audioSource;
    public AudioSource AudioSource { get { return audioSource; } }
    AudioClip clip;
    public AudioClip Clip { set { clip = value; } }

    // Use this for initialization
    void Awake()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();

        audioSource.clip = clip;
    }
}
