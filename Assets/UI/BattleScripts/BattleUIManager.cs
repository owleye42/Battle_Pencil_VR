using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{
    MonsterUIModel uiModel;
    BaseMonsterBehaviour monsterBehavior;

    private void Start()
    {
        monsterBehavior = GetComponent<OperatorController>().OperatorModel.monsterBehaviour;
        
    }

    // 生成されるタイミングで一回呼ぶ
    public void Init()
    {
        //model.monsterMaxHP = monsterBehavior.MonsterModel.hp;
        for (int i = 0; i < monsterBehavior.MonsterModel.skillList.Count; ++i)
        {
            uiModel.skillTexts[i].name = "Skill" + i;
            uiModel.skillTexts[i].text = monsterBehavior.MonsterModel.skillList[i].text;
        }
    }

    public void MonsterHPUI()
    {
        //model.HPText.text = monsterBehavior.MonsterModel.hp + " / " + model.monsterMaxHP;
    }

    //private void CharacterImageSerect()
    //{
    //    for (int i = 0; i < container.characterImages.Length; ++i)
    //    {
    //        if (monsterBehavior.MonsterModel.id == i + 1)
    //        {
    //            uiModel.characterImage = container.characterImages[i];
    //        }
    //    }
    //}

    public void SkillSelect(int num)
    {
        uiModel.frame.transform.position = uiModel.skillTexts[num].transform.position;
    }

    public void SkillDecision()
    {
        uiModel.frame.color = new Color(1f, 1f, 1f, Mathf.Clamp(Mathf.Cos(30f * Time.time), 0f, 1f));
    }
}
