using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pen : MonoBehaviour {
    Rigidbody rigidbody;
    void Start() {
        rigidbody = GetComponent<Rigidbody>();       
    }

    void Update() {
        if (this.rigidbody.velocity.magnitude <= 0)
        {
            //
            var turn = TurnManager.instance;
            if (turn.NowTurn() != TURNTYPE.CREATE)
            {
                Instantiate<GameObject>(CpuManager.instance.monster);
                TurnManager.instance.NextTurn();
                // Destroy(this.gameObject);

            }


        }
    }
    
 
}
