using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    static SoundManager instance;
    AudioSource audioSource;


    private void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(this);
            }
        }
    }




    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    //フェードイン
    public static IEnumerator FeedIn(AudioSource audioSource)
    {
        while (audioSource.volume < 1f)
        {
            audioSource.volume += Time.deltaTime / 0.1f;

            if (audioSource.volume > 1)
            {
                audioSource.volume = 1f;
            }
            yield return null;
        }
        
    }
    //フェードアウト
    public static IEnumerator FeedOut(AudioSource audioSource)
    {
        while (audioSource.volume < 1f)
        {
            audioSource.volume -= Time.deltaTime / 0.1f;

            if (audioSource.volume > 1)
            {
                audioSource.volume = 1f;
            }
            yield return null;
        }
        
    }

}
