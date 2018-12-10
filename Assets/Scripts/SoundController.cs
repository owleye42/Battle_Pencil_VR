using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : BaseSingletonMono<SoundController>
{
    private List<BGMModel> bgmModels = new List<BGMModel>();
    public List<BGMModel> BGMModels { set { bgmModels = value; } get { return bgmModels; } }

    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach(var num in bgmModels)
        {
            if (!num.audioSource.isPlaying)
            {
                num.audioSource.Play();
            }
        }

    }
}
