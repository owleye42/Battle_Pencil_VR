using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fade_In_Out : MonoBehaviour {

    bool alfaFrag;
    float a_color;
    float red, green, blue;    //RGBを操作するための変数
    [Header("透明化の速さ")]
    public float speed;  //透明化の速さ
    bool once = true;

    int phase=0;
    

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

    private void Update()
    {


        switch (phase)
        {
            case 1:
                StartCoroutine(FadeOut());
                break;
            case 2:
                StartCoroutine(FadeOut());
                break;
        }

    }

    IEnumerator FadeOut()
    {
        while (true)
        {
            GetComponent<Image>().color = new Color(red, green, blue, a_color);
            a_color += speed * Time.deltaTime;
            //透明度が255になったら終了する。
            if (a_color >= 1)
            {
                a_color = 0;
                alfaFrag = false;
            }
            yield return null;
        }
    }

    IEnumerator FadeKeep()
    {
        while (true)
        {
            GetComponent<Image>().color = new Color(red, green, blue, a_color);
            a_color += speed * Time.deltaTime;
            //透明度が255になったら終了する。
            if (a_color >= 1)
            {
                a_color = 0;
                alfaFrag = false;
            }
            yield return null;
        }
    }
    IEnumerator FadeIn()
    {
        if (alfaFrag)
        {
            GetComponent<Image>().color = new Color(red, green, blue, a_color);
            a_color -= speed * Time.deltaTime;
            //透明度が255になったら終了する。
            if (a_color <= 0)
            {
                a_color = 0;
                alfaFrag = false;
            }
            yield return null;
        }
    }
}
