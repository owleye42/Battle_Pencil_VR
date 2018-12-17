using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TURNTYPE
{
    CPUTURN=1,
    CREATE=2,
    CREATEANIM=5,
    BATTLE=3,
}

public class TurnManager : MonoBehaviour {
    
    public static TurnManager instance=null;
    TURNTYPE turnNum=0;

    GameObject nowMonster;
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
        turnNum = 0;
        
	}
    bool a = false;
    public GameObject v;
    GameObject mon;
    private void Update()
    {
        Debug.Log((int)turnNum);

        
            switch (turnNum)
            {

                case TURNTYPE.CPUTURN:

                    StartCoroutine(CpuManager.instance.ThrowBall());

                    break;

                case TURNTYPE.CREATE:

                    // var monster=Instantiate<GameObject>(CpuManager.instance.monster);
                    var monster = CpuManager.instance.monster;
                    monster.transform.position = GameManager.instance.cpuMonsterPosition.position;
                mon = monster;
                
                 
               
                    break;
            case TURNTYPE.CREATEANIM:
                
                


                break;

                case TURNTYPE.BATTLE:




                    break;

            

        }

    }



    public void NextTurn()
    {
        turnNum++;
        
    }

    public TURNTYPE NowTurn()
    {
        return turnNum;
    }
}
