using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bbb : MonoBehaviour {
    [SerializeField]
    GameObject attackObj = null;
    
    [SerializeField]
    GameObject healObj = null;

    [SerializeField]
    GameObject defenseObj = null;

    GameObject[] objects = new GameObject[2];
    BaseMonsterBehaviour[] monsterBehaviour = new BaseMonsterBehaviour[2];

    //int random = Random.Range(0, 6);

    private void Awake()
    {
        objects[0] = Instantiate(attackObj);
        monsterBehaviour[0] = objects[0].GetComponent<BaseMonsterBehaviour>();
        objects[0].name = monsterBehaviour[0].MonsterModel.name;
        
        objects[1] = Instantiate(healObj);
        monsterBehaviour[1] = objects[1].GetComponent<BaseMonsterBehaviour>();
        objects[1].name = monsterBehaviour[1].MonsterModel.name;
        monsterBehaviour[1].EnemyBehavior = monsterBehaviour[0];


    }

    // Use this for initialization
    void Start () {
        monsterBehaviour[0].EnemyBehavior = monsterBehaviour[1];
        monsterBehaviour[1].EnemyBehavior = monsterBehaviour[0];
    }

    // Update is called once per frame
    void Update () {
        
    }
}
