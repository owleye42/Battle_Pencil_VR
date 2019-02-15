using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectObject : MonoBehaviour {
   　//モンスターのプレハブの名前
    [SerializeField]
    string monsterName;

    private void Update()
    {
     }
    //握ってから頭に近づける処理
    private void OnCollisionEnter(Collision collision)
    {
        //仮処理
        if (collision.gameObject.tag == "Obj")
        {
<<<<<<< HEAD
            DataManager.Instance.prefPlayerPencil = DataManager.Instance.monsters[monsterName];
=======
            DataManager.Instance.playerModel = DataManager.Instance.monsters[monsterName];
            Fade_In_Out.Instance.FadeIO();


            
>>>>>>> db4c32e2d4c72fe8090b3ee5b93d9f97391dd55f
        }

        
    }

}
