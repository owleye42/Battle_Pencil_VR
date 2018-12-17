using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders : MonoBehaviour {
    BoxCollider collider;
	// Use this for initialization
	void Start () {
        collider = GetComponent<BoxCollider>();    
    }
    
    public void Enabled()
    {
        collider.enabled=true;
    }
    public void Disable()
    {
        collider.enabled = false;

    }
}
