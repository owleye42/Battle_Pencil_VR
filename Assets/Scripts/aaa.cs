using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour {
    [SerializeField]
    AudioClip clip;

    [SerializeField]
    AudioClip clip2;

    SoundController a;

	// Use this for initialization
	void Start () {
        a = SoundController.Instance;
        a.AudioSource.clip = clip;
        //a.Clip = clip;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            a.Clip = clip2;
            Debug.Log("aaaaa");
        }
       
	}
}
