using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public int num;
    public Action[] actions;
	// Use this for initialization
	void Start () {
        for(int i = 0; i < actions.Length; i++)
        {
            actions[i].parent = this.gameObject;
        }

        }
	
	// Update is called once per frame
	void Update () {
        if (num == 0)
        {
            return;
        }
        for (int i = 0; i < actions.Length; i++)
        {
            if (i == num)
            {
                actions[i].ActionStart();
            }
        }
    }
}
