using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : BaseSingletonMono<BattleUIManager>
{
    UIContainer container;

    MonsterUIModel model;
    BaseMonsterBehaviour monsterBehavior;

    private void Start()
    {
        Awake();
    }

    // 生成されるタイミングで一回呼ぶ
    public void Init(ref MonsterUIModel mModel, ref BaseMonsterBehaviour mBehavior)
    {
        model = mModel;
        monsterBehavior = mBehavior;

        model.monsterMaxHP = monsterBehavior.MonsterModel.hp;
        for (int i = 0; i < monsterBehavior.MonsterModel.skillList.Count; ++i)
        {
            model.skillTexts[i].name = "Skill" + i;
            model.skillTexts[i].text = monsterBehavior.MonsterModel.skillList[i].text;
        }
    }

    public void monsterHPUI()
    {
        model.HPText.text = monsterBehavior.MonsterModel.hp + " / " + model.monsterMaxHP;
    }

    private void CharacterImageSerect()
    {
        for (int i = 0; i < container.characterImages.Length; ++i)
        {
            if (monsterBehavior.MonsterModel.id == i + 1)
            {
                model.characterImage = container.characterImages[i];
            }
        }
    }

    public void SkillSelect(int num)
    {
        model.frame.transform.position = model.skillTexts[num].transform.position;
    }

    public void SkillDecision()
    {
        model.frame.color = new Color(1f, 1f, 1f, Mathf.Clamp(Mathf.Cos(30f * Time.time), 0f, 1f));
    }
}
