using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour {
    public Image UIobj;

    int color_Step = 0;//100% 0 50% 1 25%2
    float a_color;
    float red, green, blue;    //RGBを操作するための変数

    [Header("変化前の体力")]
    private int beforeHP = 100;//初期値１００と仮定
    [Header("現在の体力バーの長さ")]
    private float barLengs = 1.0f;//１と初期値とする
    [Header("変更後の体力バーの長さ")]
    private float afterBarLengs = 1.0f;//１と初期値とする
    [Header("体力バー変更時のスピード,高ければ高いほど早くなる")]
    public float barSpeed;
    [Header("体力差分(確認用)")]
    [SerializeField] float difference;
    // Update is called once per frame

    public void Init()
    {
        barLengs = 1.0f;
        afterBarLengs = 1.0f;
        color_Step = 0;
        red = 0f;
        green = 255f;
        blue = 0;
        difference = 0f;
        

    }
    public void BarUpdate(int afterHP/*変化後の体力*/)//体力値変更値時に呼ぶ関数//100,(0,255,0) 50(255,255,0) 20(255,0,0)
    {
     
        difference=(beforeHP - afterHP)/100;
        afterBarLengs -= difference;
        while (!Mathf.Approximately(barLengs , afterBarLengs))
        {
            GetComponent<Image>().color = new Color(red, green, blue, a_color);//色代入

            red = GetComponent<Image>().color.r;
            green = GetComponent<Image>().color.g;
            blue = GetComponent<Image>().color.b;

            if (barLengs > 0.5f)
            {
                color_Step = 0;
            }
            else if (barLengs>0.25f)
            {
                color_Step = 1;
            }
            else if(barLengs<=0.25f)
            {
                color_Step = 2;
            }
            switch (color_Step)
            {
                case 0:
                    red = 0f;
                    green = 255f;
                    blue = 0;
                    break;
                case 1:
                    red = 255f;
                    green = 255f;
                    blue = 0f;
                    break;
                case 2:
                    red = 255f;
                    green = 0f;
                    blue = 0f ;
                    break;
               
            }
            barLengs -= 1.0f / difference * Time.deltaTime*barSpeed;
            UIobj.fillAmount = barLengs;
        }
        
    }

    private void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        a_color = GetComponent<Image>().color.a;
       
    }

    
}
