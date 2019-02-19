using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager :BaseSingletonMono<DataManager> {

    public Transform cameraPosition;
    public Transform playPosition;

    public GameObject playerModel;
    public GameObject computerModel;
    public Dictionary<string, GameObject> monsters;

    List<string> monsterNames;
    private void Start()
    {
        StartCoroutine(Update());
        monsterNames = new List<string>();
        monsters = new Dictionary<string, GameObject>();

        object[] objList = Resources.LoadAll("Monster");
        foreach (GameObject obj in objList)
        {
            monsters[obj.name] =obj;
            monsterNames.Add(obj.name);
          
        }
        computerModel = monsters[monsterNames[Random.RandomRange(0,monsterNames.Count)]]as GameObject;
    }


    IEnumerator Update()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
           

            }
            

            yield return null;

        }
        
    }
}
