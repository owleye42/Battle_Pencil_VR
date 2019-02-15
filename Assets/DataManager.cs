using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : BaseSingletonMono<DataManager>
{

    public Transform cameraPosition;
    public Transform playPosition;

    public GameObject playerModel;
    public GameObject computerModel;
    public Dictionary<string, GameObject> monsters;

    List<string> monsterNames;

    protected override void  Awake()
    {
        base.Awake();

        monsterNames = new List<string>();
        monsters = new Dictionary<string, GameObject>();

        object[] objList = Resources.LoadAll("Monster");
        foreach (GameObject obj in objList)
        {
            monsters[obj.name] = obj;
            monsterNames.Add(obj.name);

        }

        computerModel = monsters[monsterNames[Random.Range(0, monsterNames.Count)]] as GameObject;
    }

    private void Start()
    {
        StartCoroutine(UpdateCoroutine());
    }


    IEnumerator UpdateCoroutine()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(Fade_In_Out.Instance.FadeOut(1.5f));
                yield return new WaitForSeconds(1.5f);

                cameraPosition.position = playPosition.position;
                cameraPosition.rotation = playPosition.rotation;
                StartCoroutine(Fade_In_Out.Instance.FadeIn(1f));

            }
            yield return null;
        }
    }
}
