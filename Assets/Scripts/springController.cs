using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class springController : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

    private GameObject collidingObject;

    private GameObject objectInHand;
    [Header("伝達倍率（force）")]
    [SerializeField] float forceDiameter = 1.0f;
    [Header("伝達倍率（rotation）")]
    [SerializeField] float rotationDiameter = 1.0f;



    Vector3 PenRotate = new Vector3(1000000, 0, 0);
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = col.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;
        var joint = AddSpringJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
        joint.spring = 120000f;
        joint.minDistance = 0.025f;
        joint.tolerance = 0;
    }

    private SpringJoint AddSpringJoint()
    {
        SpringJoint sp = gameObject.AddComponent<SpringJoint>();
        sp.breakForce = 2000;
        sp.breakTorque = 2000;
        return sp;
    }
    //private FixedJoint AddFixedJoint()
    //{
    //    FixedJoint fx = gameObject.AddComponent<FixedJoint>();
    //    fx.breakForce = 2000;
    //    fx.breakTorque = 2000;
    //    return fx;
    //}

    private void ReleaseObject()
    {
        if (GetComponent<SpringJoint>())
        {
            GetComponent<SpringJoint>().connectedBody = null;
            Destroy(GetComponent<SpringJoint>());

            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity * forceDiameter;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity * rotationDiameter + PenRotate;
        }

        objectInHand = null;
    }

    void Update()
    {
        if (Controller.GetHairTriggerDown())
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        if (Controller.GetHairTriggerUp())
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
    }
}
