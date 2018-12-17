using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Turn {
    syoukan,
    batlle,
    kari,
    karu2,
    
}

public class Manager : MonoBehaviour {

    public static Turn turn;


	// Use this for initialization
	void Start () {
        turn = Turn.syoukan;
	}
	
	// Update is called once per frame
	void Update () {

        if (turn == Turn.kari)
        {
            var p=GameObject.Find("player");
            var mon = GameObject.Find("mon").GetComponent<Monster>(); 
            mon.num = p.GetComponent<pencill>().num;
            turn = Turn.karu2;
        }
        if (turn == Turn.karu2)
        {

        }
		
	}


}
