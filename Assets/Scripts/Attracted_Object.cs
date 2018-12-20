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
        AttRig =AttractedObj. GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update () {
        Attracted();

    }

    void Attracted()
    {
        distance = Vector3.Distance(attractedPos, AttractedPoint.transform.position);

        Angle = AttractedObj.transform.position - transform.position;

        AttRig.AddForce(Angle.normalized * (gravity / Mathf.Pow(distance, 2)));

        if (distance <= 3)
        {
            AttRig.velocity = new Vector3(0, 0, 0);
        }
    }

        /*distance1 = Vector3.Distance(pos1, transform.position);

        t1Angle = target1.transform.position - transform.position;

        rigidbody.AddForce(t1Angle.normalized * (gravity / Mathf.Pow(distance1, 2)));*/
}
