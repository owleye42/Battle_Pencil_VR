using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PencilNumberSelect : MonoBehaviour
{
    [SerializeField]
    Text[] child;

    [SerializeField]
    Image image;


    // Use this for initialization
    void Start()
    {
        //SkillText(BattleManager.Instance.computerMonsterBehaviour.MonsterModel.skillList);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 生成されるタイミングで一回呼ぶ
    public void SkillText(List<SkillModel> skillModels)
    {
        for (int i = 0; i < skillModels.Count; ++i)
        {
            child[i].name = "Skill" + i;
            child[i].text = skillModels[i].text;
        }
    }


    public void SkillSelect(int num)
    {
        image.transform.position = child[num].transform.position;
    }

    public void SkillDecision()
    {
        //image.color = new Color(1, 1, 1, Mathf.Clamp(Mathf.Cos(30f * Time.time), 0f, 1f));
    }
}
