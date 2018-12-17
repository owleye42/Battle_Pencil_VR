using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : Action{

    public override void ActionStart()
    {
        var a = parent.GetComponent<Animator>();
        a.CrossFade("a", 0);
        
    }
}
