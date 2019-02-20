using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : BaseSingletonMono<DataManager>
{
    public Canvas titleCanvas;
    public Canvas gameCanvas;

    public Transform canvasPos;

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
    }
    private void Update()
    {
        //仮処理
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(ChengeCanvas());
        }
    }
    
    public IEnumerator ChengeCanvas()
    {
        Destroy(titleCanvas.gameObject);
        var canvas=GameObject.Instantiate<Canvas>(gameCanvas);
        canvas.transform.position = canvasPos.position;
        yield return null;
    }
    

}
