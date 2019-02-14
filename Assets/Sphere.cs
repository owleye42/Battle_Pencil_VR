using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {

    [SerializeField]
    bool onHand = false;

    [SerializeField]
    GameObject defaultPos;

    private Transform followTfm;
    float smoothTime = 0.2f;
    Vector3 velocity = Vector3.zero;
    Rigidbody rigidbody;
    [Header("中のモンスターオブジェクト")]
    [SerializeField] GameObject monsterObj;

    [SerializeField] GameObject headpos;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Head")
        {
           DataManager.Instance.playerModel = DataManager.Instance.monsters[monsterObj.name];
            Debug.Log(monsterObj.name);  
        }
        if (other.gameObject.tag == "Controller")
        {
            onHand = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Controller")
        {
            onHand =false;
            rigidbody.velocity = Vector3.zero;
        }
    }

    private void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        followTfm = defaultPos.transform;
    }

    private void Update()
    {
        //float angle = Mathf.LerpAngle(0, 0, Time.time);
        //transform.eulerAngles = new Vector3(0, angle, 0);
        if (!onHand)
        {
            Vector3 targetPos = followTfm.TransformPoint(new Vector3(0f, 0f, 0f));

            // 移動
            transform.position =
                Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
            //元の位置に戻る処理
           
        }

    }
}
