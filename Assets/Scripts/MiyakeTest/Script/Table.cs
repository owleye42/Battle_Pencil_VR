using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour {
 
    //テーブル配下のコライダー（Scene内で作っておく）
    [SerializeField] Colliders [] colliders;
    [SerializeField] BoxCollider enemyTurnCollider;
    void Start()
    {
        colliders = GetComponentsInChildren<Colliders>();
        //起動時はコライダーは消しておく
        AllDisable();
		OfEneyTurnCol();
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


    public void OnEnemyTurnCol()
    {
        enemyTurnCollider.enabled = true;
    }
    public void OfEneyTurnCol()
    {
        enemyTurnCollider.enabled = false;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //鉛筆との衝突ですべてのコライダーをonにする
    //    if (collision.gameObject.tag == "Pencill")
    //    {
    //        AllEnable();
    //    }
       
    //}

}
