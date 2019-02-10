using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//public class Fade_In_Out : BaseSingletonMono<Fade_In_Out> {

//    bool alfaFrag;
//    float a_color;
//    float red, green, blue;    //RGBを操作するための変数
//    [Header("透明化の速さ")]
//    public float speed;  //透明化の速さ
//    bool once = true;

//    int phase=0;
    

//    [Header("何秒暗転するか")]
//    public float TimeCount = 15;
//    // Use this for initialization
//    void Start()
//    {
//        red = GetComponent<Image>().color.r;
//        green = GetComponent<Image>().color.g;
//        blue = GetComponent<Image>().color.b;

//        alfaFrag = false;
//        a_color = 0;
//    }

//    public void FadeIO()
//    {
//        phase = 1;

//        switch (phase)
//        {
//            case 1:
//                StartCoroutine(FadeOut());//暗転
//                break;
//            case 2:
//                StartCoroutine(FadeKeep());//維持
//                break;
//            case 3:
//                StartCoroutine(FadeIn());//明転
//                break;
//        }

//    }

//    IEnumerator FadeOut()
//    {
//        while (true)
//        {
//            GetComponent<Image>().color = new Color(red, green, blue, a_color);
//            a_color += speed * Time.deltaTime;
//            //透明度が255になったら終了する。
//            if (a_color >= 1)
//            {
//                a_color = 1;
//                alfaFrag = false;
//                phase = 2;
//                break;
//            }
//            yield return null;
//        }
//        yield return null;
//    }

//    IEnumerator FadeKeep()
//    {
//        while (true)
//        {
//            TimeCount -= 1 * Time.deltaTime;
//            if (TimeCount <= 0)
//            {
//                TimeCount = 0;
//                phase=3;
//                break;
//            }
//            yield return null;
//        }
//        yield return null;
//    }
//    IEnumerator FadeIn()
//    {
//        while (true)
//        {
//            GetComponent<Image>().color = new Color(red, green, blue, a_color);
//            a_color -= speed * Time.deltaTime;
//            //透明度が255になったら終了する。
//            if (a_color <= 0)
//            {
//                a_color = 0;
//                alfaFrag = false;
//                break;
//            }
//            yield return null;
//        }
//        yield return null;
//    }
//}
