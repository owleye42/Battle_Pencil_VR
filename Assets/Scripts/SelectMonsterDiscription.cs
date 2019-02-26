using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMonsterDiscription : MonoBehaviour {

    [Header("モンスターの説明")]
    [SerializeField]int monsterID;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (monsterID==0)
        {
            SelectUiController.Instance.Attack();
        }
        if (monsterID == 1)
        {
            SelectUiController.Instance.Defense();
        }
        if (monsterID == 2)
        {
            SelectUiController.Instance.Recovery();
        }

    }
    
}
