using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePencill : MonoBehaviour {



    Vector3 rotatePoint = Vector3.zero;  //回転の中心
    Vector3 rotateAxis = Vector3.zero;   //回転軸
    float angle = 0f;                //回転角度

    [SerializeField] float cubeSizeHalf;                  //キューブの大きさの半分
    [SerializeField] bool isRotate = false;               //回転中に立つフラグ。回転中は入力を受け付けない

    [SerializeField] float speed = 15;
    [SerializeField] float kaiten = 1800;



    private void Start()
    {
        StartCoroutine(up());
    }

    IEnumerator up()
    {
        while (true)
        {
            if (isRotate)
            {
                rotatePoint = transform.position + new Vector3(cubeSizeHalf, -cubeSizeHalf, 0f);
                rotateAxis = transform.forward;
                StartCoroutine(MoveCube());
                yield break;

            }
            yield return null;

        }
    }

    

    IEnumerator MoveCube()
    {

        //回転処理
        float sumAngle = 0f; //angleの合計を保存
        while (sumAngle < kaiten)
        {

            angle = speed; //ここを変えると回転速度が変わる
            sumAngle += angle;

            // kaiten以上回転しないように値を制限
            if (sumAngle > kaiten)
            {
                angle -= sumAngle + kaiten;
            }
            transform.RotateAround(rotatePoint, rotateAxis, angle);

            yield return null;

        }
        //回転中のフラグを倒す
        isRotate = false;

        yield break;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "table")
        {
            isRotate = true;
        }


    }
}
