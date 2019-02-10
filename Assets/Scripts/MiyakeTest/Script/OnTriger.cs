using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriger : MonoBehaviour {
    GameObject parent;
    Colliders[] colliders;

    void Start () {
        parent = transform.parent.gameObject;
        colliders = parent.gameObject.GetComponentsInChildren<Colliders>();
        foreach (var coll in colliders)
        {
            coll.Disable();
        }

    }
	
	
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pencill")
        {
            foreach(var coll in colliders)
            {
                coll.Enabled();
            }
        }
    }
}
