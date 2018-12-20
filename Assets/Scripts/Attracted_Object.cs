using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attracted_Object : MonoBehaviour {
    private float gravity = 8000;

    public GameObject AttractedPoint;
    public GameObject AttractedObj;

    private Rigidbody AttRig;

    private Vector3 attractedPos;
    private float distance;

    private Vector3 Angle;

    private void Start()
    {
        attractedPos = AttractedObj.transform.position;
        AttRig=
    }
    // Update is called once per frame
    void Update () {
        
	}

    void Attracted()
    {
        distance = Vector3.Distance(attractedPos, AttractedPoint.transform.position);

        Angle = AttractedObj.transform.position - transform.position;

      AttractedObj.AddForce(Angle.normalized * (gravity / Mathf.Pow(distance, 2)));
    }

        /*distance1 = Vector3.Distance(pos1, transform.position);

        t1Angle = target1.transform.position - transform.position;

        rigidbody.AddForce(t1Angle.normalized * (gravity / Mathf.Pow(distance1, 2)));*/
}
