using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fade_In_Out : BaseSingletonMono<Fade_In_Out> {

    bool alfaFrag;
    float a_color;
    float red, green, blue;    //RGBを操作するための変数
    [Header("透明化の速さ")]
    public float speed;  //透明化の速さ
    bool once = true;

    int phase=1;
    

    [Header("何秒暗転するか")]
    public float TimeCount = 15;
    // Use this for initialization
    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;

        alfaFrag = false;
        a_color = 0;
    }

    public IEnumerator FadeIO(float outSpeed, float keepTime, float inSpeed, System.Action corInKeep)
    {
		var cor = StartCoroutine(FadeOut(outSpeed));
		yield return cor;

		cor = StartCoroutine(FadeKeep(keepTime / 2));
		yield return cor;

		corInKeep();
		yield return new WaitForEndOfFrame();

		cor = StartCoroutine(FadeKeep(keepTime / 2));
		yield return cor;

		cor = StartCoroutine(FadeIn(inSpeed));
		yield return cor;
	}

    public void StartFade(float outTime, float keepTime, float inTime, System.Action corInKeep)
    {
		StartCoroutine(FadeIO(outTime, keepTime, inTime, corInKeep));
    }

    

    public IEnumerator FadeOut(float _speed )
    {
        while (true)
        {
            GetComponent<Image>().color = new Color(red, green, blue, a_color);
            a_color += _speed * Time.deltaTime;
            //透明度が255になったら終了する。
            if (a_color >= 1)
            {
                a_color = 1;
                alfaFrag = false;
                phase = 2;
                Debug.Log("OUT");
                
                break;
            }
            yield return null;
        }
        yield return null;
    }

    IEnumerator FadeKeep(float keepTime)
    {
        while (true)
        {
            GetComponent<Image>().color = new Color(red, green, blue, 255);
            Debug.Log("KEEP");
            keepTime -= 1 * Time.deltaTime;

            if (keepTime <= 0)
            {
                keepTime = 0;
                //phase=3;
                Debug.Log("KEEP END");
                break;
            }
            yield return null;
        }
        yield return null;
    }
    public IEnumerator FadeIn(float _speed)
    {
        while (true)
        {
            GetComponent<Image>().color = new Color(red, green, blue, a_color);
            a_color -= _speed * Time.deltaTime;
            //透明度が255になったら終了する。
            if (a_color <= 0)
            {
                a_color = 0;
                alfaFrag = false;
                Debug.Log("IN");
                once = false;
                break;
            }
            yield return null;
        }
        yield return null;
    }
}
