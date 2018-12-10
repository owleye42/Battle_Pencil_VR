using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : BaseSingletonMono<SoundController>
{
    public AudioSource AudioSource { get; set; }
    public AudioSource AudioSource2 { get; set; }

    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();

        if (AudioSource == null)
        {
            AudioSource = gameObject.AddComponent<AudioSource>();
            AudioSource.loop = true;
        }

        if (AudioSource2 == null)
        {
            AudioSource2 = gameObject.AddComponent<AudioSource>();
            AudioSource2.loop = true;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!AudioSource.isPlaying)
            AudioSource.Play();

        if (!AudioSource2.isPlaying)
            AudioSource2.Play();
    }
}
