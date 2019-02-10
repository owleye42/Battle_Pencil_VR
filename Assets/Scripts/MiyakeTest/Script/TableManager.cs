using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour {
    public static TableManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance != this)
        {
            Destroy(this);
        }
    }

    public Table playerTabel;
    public Table cpuTable;
	
	// Update is called once per frame
	void Update () {
		
	}
}
