using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour {
　　//テーブル配下のコライダー（Scene内で作っておく）
    [SerializeField] BoxCollider[] colliders;

    void Start () {
        colliders = GetComponentsInChildren<BoxCollider>();
        //起動時はコライダーは消しておく
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled =false;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //鉛筆との衝突ですべてのコライダーをonにする
       if(collision.gameObject.tag=="Pencill")
        for (int i = 0; i < colliders.Length; i++)
        {        
                colliders[i].enabled=true;
            
        }
    }

}
