using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectObject : MonoBehaviour {
   　//モンスターのプレハブの名前
    [SerializeField]
    string monsterName;
    
    //握ってから頭に近づける処理
    private void OnCollisionEnter(Collision collision)
    {
        //仮処理
        if (collision.gameObject.tag == "Obj")
        {
            DataManager.Instance.playerModel = DataManager.Instance.monsters[monsterName];
        }

        
    }

}
