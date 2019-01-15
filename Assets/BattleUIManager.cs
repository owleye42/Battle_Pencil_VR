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

    [SerializeField]
    Image[] characterImages = null;

    // 仮の変数
    bool isPlayer = false;

    
    public void monsterHPUI()
    {
        if (isPlayer)
            playerUIModel.HPText.text = BattleManager.Instance.playerMonsterBehaviour.MonsterModel.hp + " / " + playerUIModel.monsterMaxHP;
        else
            enemyUIModel.HPText.text = BattleManager.Instance.computerMonsterBehaviour.MonsterModel.hp + " / " + enemyUIModel.monsterMaxHP;
    }

    // 生成されるタイミングで一回呼ぶ
    public void Init()
    {
        if (isPlayer)
        {
            playerUIModel.monsterMaxHP = BattleManager.Instance.playerMonsterBehaviour.MonsterModel.hp;
            for (int i = 0; i < BattleManager.Instance.playerMonsterBehaviour.MonsterModel.skillList.Count; ++i)
            {
                playerUIModel.skillTexts[i].name = "Skill" + i;
                playerUIModel.skillTexts[i].text = BattleManager.Instance.playerMonsterBehaviour.MonsterModel.skillList[i].text;
                
            }
        }
        else
        {
            enemyUIModel.monsterMaxHP = BattleManager.Instance.computerMonsterBehaviour.MonsterModel.hp;
            for (int i = 0; i < BattleManager.Instance.computerMonsterBehaviour.MonsterModel.skillList.Count; ++i)
            {
                enemyUIModel.skillTexts[i].name = "Skill" + i;
                enemyUIModel.skillTexts[i].text = BattleManager.Instance.computerMonsterBehaviour.MonsterModel.skillList[i].text;
            }
        }
    }

    private void CharacterImageSerect()
    {
        if (isPlayer)
        {
            for (int i = 0; i < characterImages.Length; ++i)
            {
                if (BattleManager.Instance.playerMonsterBehaviour.MonsterModel.id == i + 1)
                {
                    playerUIModel.characterImage = characterImages[i];
                }
            }
        }
        else
        {
            for (int i = 0; i < characterImages.Length; ++i)
            {
                if (BattleManager.Instance.computerMonsterBehaviour.MonsterModel.id == i + 1)
                {
                    enemyUIModel.characterImage = characterImages[i];
                }
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
