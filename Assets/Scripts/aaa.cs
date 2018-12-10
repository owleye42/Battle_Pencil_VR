using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour {
    [SerializeField]
    AudioClip clip;

    [SerializeField]
    AudioClip clip2;

    // Use this for initialization
    void Start()
    {
        SoundController.Instance.AudioSource.clip = clip;
        SoundController.Instance.AudioSource2.clip = clip2;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            SoundController.Instance.AudioSource.clip = clip2;
        }
       
	}
}
