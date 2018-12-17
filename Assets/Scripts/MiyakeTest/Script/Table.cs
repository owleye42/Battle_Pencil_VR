using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour {
    public static Table instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    //テーブル配下のコライダー（Scene内で作っておく）
    [SerializeField] Colliders [] colliders;

    void Start()
    {
        colliders = GetComponentsInChildren<Colliders>();
        //起動時はコライダーは消しておく
        AllDisable();
    }

    //枠を作る
    public void AllEnable()
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].Enabled();

        }
    }
    //枠を消す
    public void AllDisable()
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].Disable();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //鉛筆との衝突ですべてのコライダーをonにする
        if (collision.gameObject.tag == "Pencill")
        {
            AllEnable();
        }
       
    }

}
