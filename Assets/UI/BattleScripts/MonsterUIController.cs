using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterUIController : MonoBehaviour
{
	public enum EOperatorUI {
		PlayerUI, ComputerUI
	}

	[SerializeField]
	EOperatorUI operatorUI;

    [SerializeField]
    MonsterUIModel uiModel;
    
    OperatorModel operatorModel;

    private IEnumerator Start() {
		while (OperatorManager.Instance == null
			|| OperatorManager.Instance == null) {
			yield return null;
		}

		while (OperatorManager.Instance.PlayerController == null
			|| OperatorManager.Instance.ComputerController == null) {
			yield return null;
		}

		while (OperatorManager.Instance.PlayerController.OperatorModel == null
			|| OperatorManager.Instance.ComputerController.OperatorModel == null) {
			yield return null;
		}

		if (operatorUI == EOperatorUI.PlayerUI) {
			operatorModel = OperatorManager.Instance.PlayerController.OperatorModel;
		}
		else if (operatorUI == EOperatorUI.ComputerUI) {
			operatorModel = OperatorManager.Instance.ComputerController.OperatorModel;
		}

		operatorModel.monsterUI = this;

        SkillSelect(0);
    }

    // 生成されるタイミングで一回呼ぶ
    public void Init()
    {
        var maxHP = operatorModel.monsterBehaviour.MonsterModel.hp;

        uiModel.HPText.text = operatorModel.monsterBehaviour.MonsterModel.hp + "/" + maxHP;
        uiModel.monsterName.text = operatorModel.monsterBehaviour.MonsterModel.name;

        for (int i = 0; i < operatorModel.monsterBehaviour.MonsterModel.skillList.Count; ++i)
        {
            uiModel.skillTexts[i].name = "Skill" + i;

            // タイプによってテキスト変更
            if (operatorModel.monsterBehaviour.MonsterModel.skillList[i].skillType == SkillType.ATTACK)
            {
                uiModel.skillTexts[i].text = "あいてに" + operatorModel.monsterBehaviour.MonsterModel.skillList[i].power + "ダメージ";
            }
            else if (operatorModel.monsterBehaviour.MonsterModel.skillList[i].skillType == SkillType.SKILL)
            {
                if (operatorModel.monsterBehaviour.MonsterModel.type == Type.ATTACK)
                    uiModel.skillTexts[i].text = "あいてに" + operatorModel.monsterBehaviour.MonsterModel.skillList[i].power + "ダメージ";
                else if (operatorModel.monsterBehaviour.MonsterModel.type == Type.DEFENCE)
                    uiModel.skillTexts[i].text = "カウンター";
                else if (operatorModel.monsterBehaviour.MonsterModel.type == Type.HEAL)
                    uiModel.skillTexts[i].text = "たいりょくを" + operatorModel.monsterBehaviour.MonsterModel.skillList[i].power + "かいふく";
            }
            else if (operatorModel.monsterBehaviour.MonsterModel.skillList[i].skillType == SkillType.MISS)
            {
                uiModel.skillTexts[i].text = "ミス";
            }
        }

        if(operatorModel.monsterBehaviour.MonsterModel.id == 1)
            uiModel.characterImage.sprite = BlackBoardManager.Instance.StandingSprite[0];
        else if(operatorModel.monsterBehaviour.MonsterModel.id == 2)
            uiModel.characterImage.sprite = BlackBoardManager.Instance.StandingSprite[1];
        else if(operatorModel.monsterBehaviour.MonsterModel.id == 3)
            uiModel.characterImage.sprite = BlackBoardManager.Instance.StandingSprite[2];

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
