using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class korogari : MonoBehaviour {
    Vector3 rotatePoint = Vector3.zero;  //回転の中心
    Vector3 rotateAxis = Vector3.zero;   //回転軸
    float cubeAngle = 0f;                //回転角度

    float cubeSizeHalf;                  //キューブの大きさの半分
    bool isRotate = false;               //回転中に立つフラグ。回転中は入力を受け付けない

    // Use this for initialization
    void Start () {
        cubeSizeHalf = transform.localScale.x / 2f;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("local"+transform.localScale);
        //回転中は入力を受け付けない
        if (isRotate)
            return;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotatePoint = transform.position + new Vector3(cubeSizeHalf, -cubeSizeHalf, 0f);
            transform.RotateAround(rotatePoint,new Vector3(0,0,1),20);
            transform.Rotate(0,0,4);

        }
            if (Input.GetKeyDown(KeyCode.A))
        {
           //otatePoint = transform.forward + new Vector3(cubeSizeHalf, -cubeSizeHalf, 0f);
            rotateAxis = new Vector3(0, 0, -1);
            MoveCube();
        }
    }

    void MoveCube()
    {
        //回転中のフラグを立てる
        isRotate = true;

        //回転処理
        float sumAngle = 0f; //angleの合計を保存
        while (sumAngle < 120f)
        {
            cubeAngle = 15f; //ここを変えると回転速度が変わる
            sumAngle += cubeAngle;

            // 90度以上回転しないように値を制限
            if (sumAngle > 120f)
            {
                cubeAngle -= sumAngle - 120f;
            }
            transform.RotateAround(rotatePoint, rotateAxis, cubeAngle);

           
        }

        //回転中のフラグを倒す
        isRotate = false;

    }
}
