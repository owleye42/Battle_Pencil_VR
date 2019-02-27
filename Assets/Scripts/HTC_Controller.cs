using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class HTC_Controller : MonoBehaviour {
    private SteamVR_TrackedObject trackedObj;

    private GameObject collidingObject;

    private GameObject objectInHand;
    [Header("伝達倍率（force）")]
    [SerializeField] float forceDiameter=1.0f;
    [Header("伝達倍率（rotation）")]
    [SerializeField] float rotationDiameter=1.0f;

    [Header("自レイヤー")]
    [SerializeField] public int layer1 ;//当たり判定透過レイヤー
    [SerializeField] public int layer2 ;//当たり判定透過するレイヤー

    Vector3 PenRotate = new Vector3(12.0f, 0, 0);
    Vector3 PenVector = new Vector3(0, 0, 1f);
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

   void Awake()
    {
        layer1 = LayerMask.NameToLayer("Default");
        layer2 = LayerMask.NameToLayer("Default");

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
        Physics.IgnoreLayerCollision(layer1,layer2);
        //objectInHand.GetComponent<MeshCollider>().enabled = false;//めり込み防止用　コライダーオフ
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 50000;
        fx.breakTorque = 50000;
        return fx;
    }

    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            Physics.IgnoreLayerCollision(layer1, layer2,false);
            //objectInHand.GetComponent<MeshCollider>().enabled = true;//めり込み防止用　コライダーオン
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity*rotationDiameter+PenRotate;
            objectInHand.GetComponent<Rigidbody>().AddTorque(PenRotate, ForceMode.Impulse);
            objectInHand.GetComponent<Rigidbody>().AddForce(PenVector*forceDiameter, ForceMode.Impulse);

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
