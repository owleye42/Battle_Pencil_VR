using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUiController : BaseSingletonMono<SelectUiController> {
    [Header("モンスターの説明")]
    [SerializeField] Text AttackText;
    [Header("他モンスターの説明1")]
    [SerializeField] Text DefenseText;
    [Header("他モンスターの説明2")]
    [SerializeField] Text RecoveryText ;

 
   
    public void Attack()
    {
        DefenseText.GetComponent<DiscriptionUITextAlpha>().Disappear();
        RecoveryText.GetComponent<DiscriptionUITextAlpha>().Disappear();
        AttackText.GetComponent<DiscriptionUITextAlpha>().Appear();
    }
    public void Defense()
    {
        AttackText.GetComponent<DiscriptionUITextAlpha>().Disappear();
        RecoveryText.GetComponent<DiscriptionUITextAlpha>().Disappear();
        DefenseText.GetComponent<DiscriptionUITextAlpha>().Appear();
    }
    public void Recovery()
    {
        AttackText.GetComponent<DiscriptionUITextAlpha>().Disappear();
        DefenseText.GetComponent<DiscriptionUITextAlpha>().Disappear();
        RecoveryText.GetComponent<DiscriptionUITextAlpha>().Appear();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
