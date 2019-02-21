using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMonsterDiscription : MonoBehaviour {

    [Header("モンスターの説明")]
    [SerializeField] GameObject DescriptionObj;
    [Header("他モンスターの説明1")]
    [SerializeField] GameObject otherObj1;
    [Header("他モンスターの説明2")]
    [SerializeField] GameObject otherObj2;
    
    private void Start()
    {
        DescriptionObj.GetComponent<DiscriptionUITextAlpha>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            otherObj1.GetComponent<DiscriptionUITextAlpha>().Disappear();
            otherObj2.GetComponent<DiscriptionUITextAlpha>().Disappear();
            DescriptionObj.GetComponent<DiscriptionUITextAlpha>().Appear();

            Debug.Log(DescriptionObj.name);
        }
 
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Laser")
    //    {
    //        DescriptionObj.GetComponent<DiscriptionUITextAlpha>().Disappear();
    //    }
    //}
}
