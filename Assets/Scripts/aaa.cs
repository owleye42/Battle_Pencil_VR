using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour
{
    [SerializeField]
    private AudioClip clip;
    [SerializeField]
    private AudioClip clip2;

    private BGMModel bgmModel = new BGMModel();

    // Use this for initialization
    void Start()
    {
        bgmModel.audioSource = SoundController.Instance.gameObject.AddComponent<AudioSource>();
        bgmModel.audioSource.clip = clip;
        SoundController.Instance.BGMModels.Add(bgmModel);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
