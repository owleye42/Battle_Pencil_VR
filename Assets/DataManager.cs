using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager :BaseSingletonMono<DataManager> {
<<<<<<< HEAD
    
    public GameObject prefPlayerPencil;
    public GameObject prefComputerPencil;
=======

    public Transform cameraPosition;
    public Transform playPosition;

    public GameObject playerModel;
    public GameObject computerModel;
>>>>>>> db4c32e2d4c72fe8090b3ee5b93d9f97391dd55f
    public Dictionary<string, GameObject> monsters;

    List<string> monsterNames;

    private void Start()
    {
<<<<<<< HEAD

        //monsterNames = new List<string>();
        //monsters = new Dictionary<string, GameObject>();

        //var objList = Resources.LoadAll("Monster") as GameObject[];
        //foreach (GameObject obj in objList)
        //{
        //    monsters[obj.name] = obj;
        //    monsterNames.Add(obj.name);
        //}

        ////object[] effectList = Resources.LoadAll("Effect");
=======
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

>>>>>>> db4c32e2d4c72fe8090b3ee5b93d9f97391dd55f

    IEnumerator Update()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(Fade_In_Out.Instance.FadeOut(1.5f));
                yield return new WaitForSeconds(1.5f);

<<<<<<< HEAD
        //computerPencil = monsters[monsterNames[Random.RandomRange(0,1)]]as GameObject;
    }
=======
                cameraPosition.position = playPosition.position;
                cameraPosition.rotation = playPosition.rotation;
                StartCoroutine(Fade_In_Out.Instance.FadeIn(1f));
>>>>>>> db4c32e2d4c72fe8090b3ee5b93d9f97391dd55f

            }
            

            yield return null;

        }
        
    }
}
