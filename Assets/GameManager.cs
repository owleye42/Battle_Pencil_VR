using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject playerPencil;
    public GameObject cpuPencill;
    public GameObject[] monster;
    public  static GameManager instance=null;

    public Transform playerMonsterPosotion;
    public Transform cpuMonsterPosition;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Start () {
		
	}
	
	void Update () {
	
        

	}

    public void UpUp(GameObject obj)
    {
        if (obj.transform.position.y <= cpuMonsterPosition.position.y)
        {
            obj.transform.position+=new Vector3(0,+0.1f,0);
        }
    }
}
