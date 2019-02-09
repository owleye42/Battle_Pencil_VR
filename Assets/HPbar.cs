using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour {
    public Image UIobj;

    int color_Step = 0;
    float a_color;
    float red, green, blue;    //RGBを操作するための変数

    [Header("変化前の体力")]
    private　int beforeHP=100;//初期値１００と仮定
    [Header("現在の体力バーの長さ")]
    private float barLengs=1.0f;//１と初期値とする
    [Header("変更後の体力バーの長さ")]
    private float afterBarLengs = 1.0f;//１と初期値とする
    [Header("体力バー変更時のスピード、何秒で変化完了するか")]
    public float barSpeed;
    [Header("色変化のスピード")]
    [SerializeField] float colorSpeed;
    [Header("増減フラグ")]
    [SerializeField] bool PMflag; //true増 false減
    [Header("体力差分")]
    [SerializeField] int difference; //true増 false減
                                  // Update is called once per frame

    public void BarUpdate(int afterHP/*変化後の体力*/)//体力値変更値時に呼ぶ関数
    {
        if (beforeHP < afterHP)
        {
            PMflag = false;
        }
        else
        {
            PMflag = true;
        }
        difference=beforeHP - afterHP;
        while (barLengs == afterBarLengs)
        {
            GetComponent<Image>().color = new Color(red, green, blue, a_color);//色代入

            red = GetComponent<Image>().color.r;
            green = GetComponent<Image>().color.g;
            blue = GetComponent<Image>().color.b;

            switch (color_Step)
            {
                case 0:
                    Debug.Log(green);
                    green += colorSpeed / barSpeed * Time.deltaTime;
                    if (green >= 1.0f)
                    {
                        Debug.Log("充填完了");
                        color_Step++;
                    }
                    break;
                case 1:
                    blue -= colorSpeed / barSpeed * Time.deltaTime;
                    if (blue <= 0.0f)
                    {
                        Debug.Log("充填完了");
                        color_Step++;
                    }
                    break;
                case 2:
                    red += colorSpeed / barSpeed * Time.deltaTime;
                    if (red >= 1.0f)
                    {
                        Debug.Log("充填完了");
                        color_Step++;
                    }
                    break;
                case 3:
                    green -= colorSpeed / barSpeed * Time.deltaTime;
                    if (green <= 0.0f)
                    {
                        Debug.Log("最終充填完了");
                        color_Step++;
                    }
                    break;
            }
            UIobj.fillAmount -= difference / barSpeed * Time.deltaTime;
            if (UIobj.fillAmount <= 0)
            {
                //変更終了時の挙動 
            }
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
