using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PencilNumberSelect : MonoBehaviour {
    [SerializeField]
    private BaseMonsterBehaviour baseMonsterBehaviour;

    [SerializeField]
    Transform grid;

    [SerializeField]
    List<Text> child;

	// Use this for initialization
	void Start () {
        for(int i= 0; i < 6; ++i)
        {
            child[i].name = "Skill" + i;
            if (baseMonsterBehaviour.MonsterModel.skillList[i].skillType == SkillType.Attack)
            {
                child[i].text = "モンスターに" + baseMonsterBehaviour.MonsterModel.skillList[i].power + "のダメージ";
            }
             else if (baseMonsterBehaviour.MonsterModel.skillList[i].skillType == SkillType.Heal)
            {
                child[i].text = "HP" + baseMonsterBehaviour.MonsterModel.skillList[i].power + "かいふく";
            }
            else if (baseMonsterBehaviour.MonsterModel.skillList[i].skillType == SkillType.Miss)
            {
                child[i].text = "ミス";
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
