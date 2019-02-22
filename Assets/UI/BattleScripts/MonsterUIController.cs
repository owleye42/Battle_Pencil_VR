using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterUIController : MonoBehaviour
{
    [SerializeField]
    MonsterUIModel uiModel;
    BaseMonsterBehaviour monsterBehavior;

    OperatorModel operatorModel;

    private void Start()
    {
        operatorModel = GetComponent<OperatorController>().OperatorModel;
        if (operatorModel.eOperator == OperatorModel.EOperator.Player)
            uiModel = DataManager.Instance.uiModel[0];
        else if (operatorModel.eOperator == OperatorModel.EOperator.Computer)
            uiModel = DataManager.Instance.uiModel[1];

        operatorModel.monsterUI = this;

        SkillSelect(0);
    }

    // 生成されるタイミングで一回呼ぶ
    public void Init()
    {
        monsterBehavior = operatorModel.monsterBehaviour;

        var maxHP = monsterBehavior.MonsterModel.hp;

        uiModel.HPText.text = monsterBehavior.MonsterModel.hp + "/" + maxHP;
        uiModel.monsterName.text = monsterBehavior.MonsterModel.name;

        for (int i = 0; i < monsterBehavior.MonsterModel.skillList.Count; ++i)
        {
            uiModel.skillTexts[i].name = "Skill" + i;

            // タイプによってテキスト変更
            if (monsterBehavior.MonsterModel.skillList[i].skillType == SkillType.ATTACK)
            {
                uiModel.skillTexts[i].text = "あいてに" + monsterBehavior.MonsterModel.skillList[i].power + "ダメージ";
            }
            else if (monsterBehavior.MonsterModel.skillList[i].skillType == SkillType.SKILL)
            {
                if (monsterBehavior.MonsterModel.type == Type.ATTACK)
                    uiModel.skillTexts[i].text = "あいてに" + monsterBehavior.MonsterModel.skillList[i].power + "ダメージ";
                else if (monsterBehavior.MonsterModel.type == Type.DEFENCE)
                    uiModel.skillTexts[i].text = "カウンター";
                else if (monsterBehavior.MonsterModel.type == Type.HEAL)
                    uiModel.skillTexts[i].text = "たいりょくを" + monsterBehavior.MonsterModel.skillList[i].power + "かいふく";
            }
            else if (monsterBehavior.MonsterModel.skillList[i].skillType == SkillType.MISS)
            {
                uiModel.skillTexts[i].text = "ミス";
            }
        }
    }

    public void SkillSelect(int num)
    {
        if (num - 1 >= 0)
            uiModel.frame.transform.position = uiModel.skillTexts[num - 1].transform.position;
    }

    public void SkillDecision()
    {
        uiModel.frame.color = new Color(1f, 1f, 1f, Mathf.Clamp(Mathf.Cos(30f * Time.time), 0f, 1f));
    }
}
