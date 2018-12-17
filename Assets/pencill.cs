using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pencill : MonoBehaviour {
    [SerializeField] int damegeValue;
    [SerializeField] int healValue;
    [SerializeField] int gurdValue;
    [SerializeField] int hp;
    public Action[] actions;
    public int num=0;

    public GameObject monsterPlef;
    


    private void Update()
    {
        if (num == 0)
        {
            return;

            for (int i = 0; i < actions.Length; i++)
            {
                if (i == num)
                {
                    actions[i].ActionStart();
                }
            }
        }
    }

    public void UseAction()
    {
        actions[num].ActionStart();
        
    }


}
