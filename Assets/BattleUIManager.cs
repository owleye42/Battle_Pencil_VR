using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour 
{
    [SerializeField]
    MonsterUIModel playerUIModel;
    [SerializeField]
    MonsterUIModel enemyUIModel;

    // 仮の変数
    bool isPlayer = false;

    
    public void monsterHPUI()
    {
        if (isPlayer)
            playerUIModel.HPText.text = MonsterManager.Instance.PlayerMonsterBehaviour.MonsterModel.hp + " / " + playerUIModel.monsterMaxHP;
        else
            enemyUIModel.HPText.text = MonsterManager.Instance.ComputerMonsterBehaviour.MonsterModel.hp + " / " + enemyUIModel.monsterMaxHP;
    }

    // 生成されるタイミングで一回呼ぶ
    public void Init()
    {
        if (isPlayer)
        {
            playerUIModel.monsterMaxHP = MonsterManager.Instance.PlayerMonsterBehaviour.MonsterModel.hp;
            for (int i = 0; i < MonsterManager.Instance.PlayerMonsterBehaviour.MonsterModel.skillList.Count; ++i)
            {
                playerUIModel.skillTexts[i].name = "Skill" + i;
                playerUIModel.skillTexts[i].text = MonsterManager.Instance.PlayerMonsterBehaviour.MonsterModel.skillList[i].text;
            }
        }
        else
        {
            enemyUIModel.monsterMaxHP = MonsterManager.Instance.ComputerMonsterBehaviour.MonsterModel.hp;
            for (int i = 0; i < MonsterManager.Instance.ComputerMonsterBehaviour.MonsterModel.skillList.Count; ++i)
            {
                enemyUIModel.skillTexts[i].name = "Skill" + i;
                enemyUIModel.skillTexts[i].text = MonsterManager.Instance.ComputerMonsterBehaviour.MonsterModel.skillList[i].text;
            }
        }
    }

    public void SkillSelect(int num)
    {
        if (isPlayer)
            playerUIModel.frame.transform.position = playerUIModel.skillTexts[num].transform.position;
        else
            enemyUIModel.frame.transform.position = enemyUIModel.skillTexts[num].transform.position;
    }

    public void SkillDecision()
    {
        if(isPlayer)
            playerUIModel.frame.color = new Color(1f, 1f, 1f, Mathf.Clamp(Mathf.Cos(30f * Time.time), 0f, 1f));
        else
            enemyUIModel.frame.color = new Color(1f, 1f, 1f, Mathf.Clamp(Mathf.Cos(30f * Time.time), 0f, 1f));
    }
}
