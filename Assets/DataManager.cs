using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager :BaseSingletonMono<DataManager> {
    
    public GameObject prefPlayerPencil;
    public GameObject prefComputerPencil;
    public Dictionary<string, GameObject> monsters;

    List<string> monsterNames;

    private void Start()
    {

        //monsterNames = new List<string>();
        //monsters = new Dictionary<string, GameObject>();

        //var objList = Resources.LoadAll("Monster") as GameObject[];
        //foreach (GameObject obj in objList)
        //{
        //    monsters[obj.name] = obj;
        //    monsterNames.Add(obj.name);
        //}

        ////object[] effectList = Resources.LoadAll("Effect");


        //computerPencil = monsters[monsterNames[Random.RandomRange(0,1)]]as GameObject;
    }

    
    


}
