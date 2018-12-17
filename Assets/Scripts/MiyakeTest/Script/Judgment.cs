using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//出目判定用クラス
//空のobj等に張り付けて使う
public class Judgment : MonoBehaviour {
    public static Judgment instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }



    public GameObject target;
    RaycastHit hit;
    Ray ray;


    private void Update()
    {
        LuckDetermination();
    }

    //出目判定
    public int LuckDetermination()
    {
        int num = 0;
        //鉛筆の上からRayを出して判定
        this.transform.position = target.transform.position + Vector3.up;

        ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out hit, 1))
        {
            if (hit.collider.tag == "numbers")
            {
                num = hit.collider.gameObject.GetComponent<number>().num;
                Debug.Log("出目" + num);
                return num;
            }
        }
        return num;
    }
    private void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position, new Vector3(0, -10, 0));
        Debug.DrawRay(ray.origin, new Vector3(0, -1, 0), Color.gray);
        Gizmos.DrawRay(ray);

    }
}
