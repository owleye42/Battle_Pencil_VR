using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorasTimer : MonoBehaviour {
   
    public Image UIobj;
    
    int color_Step=0;
    float a_color;
    float red, green, blue;    //RGBを操作するための変数

    [Header("タイマーカウント")]
    public float countTime ;
    [Header("色変化のスピード")]
    [SerializeField] float colorSpeed;
    // Update is called once per frame
    public void TimerCountDown()//タイマー開始用関数
    {
        StartCoroutine(Timer());
    }

    private void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        a_color = GetComponent<Image>().color.a;
        TimerCountDown();
    }


    public IEnumerator Timer()
    {
        while (true)
        {
            GetComponent<Image>().color = new Color(red , green, blue, a_color);//色代入

            red = GetComponent<Image>().color.r;
            green = GetComponent<Image>().color.g;
            blue = GetComponent<Image>().color.b;
            switch (color_Step) {
                case 0:
                    Debug.Log(green);
                    green += colorSpeed / countTime * Time.deltaTime;
                    if (green >= 1.0f)
                    {
                        Debug.Log("充填完了");
                        color_Step++;
                    }
                    break;
                case 1:
                    blue -= colorSpeed / countTime * Time.deltaTime;
                    if (blue <= 0.0f)
                    {
                        Debug.Log("充填完了");
                        color_Step++;
                    }
                    break;
                case 2:
                    red += colorSpeed / countTime * Time.deltaTime;
                    if (red >= 1.0f)
                    {
                        Debug.Log("充填完了");
                        color_Step++;
                    }
                    break;
                case 3:
                    green -= colorSpeed / countTime * Time.deltaTime;
                    if (green <=0.0f)
                    {
                        Debug.Log("最終充填完了");
                        color_Step++;
                    }
                    break;
            }
            UIobj.fillAmount -= 1.0f / countTime * Time.deltaTime;
            if (UIobj.fillAmount <= 0) { break; }
               
            
            yield return null;
        }
    }
}
