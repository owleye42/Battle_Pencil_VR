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
    
    public bool IsDecision { get; set; }
    float elapsedTime = 0f;

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
        uiModel.HPText.text = operatorModel.monsterBehaviour.MonsterModel.hp + "/" + operatorModel.monsterBehaviour.MonsterModel.maxHP;
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
        IsDecision = false;
        
        elapsedTime += Time.deltaTime;
        if (elapsedTime <= 1f)
        {
            uiModel.frame.color = new Color(1f, 1f, 1f, Mathf.Abs(Mathf.Cos(10f * elapsedTime)));
        }
        else
        {
            IsDecision = true;
            elapsedTime = 0f;
            uiModel.frame.color = new Color(1f, 1f, 1f);
        }
    }

    public void AAA(int damage)
    {
        while (damage != 0)
        {
            //　ダメージ量を10で割った商をHPから減らす
            var tempDamage = damage / 10;
            //　商が0になったら余りを減らす
            if (tempDamage == 0)
            {
                tempDamage = damage % 10;
            }

            Debug.Log(tempDamage);
            operatorModel.monsterBehaviour.MonsterModel.hp -= tempDamage;
            uiModel.HPText.text = operatorModel.monsterBehaviour.MonsterModel.hp + "/" + operatorModel.monsterBehaviour.MonsterModel.maxHP;
            uiModel.HPBar.value = operatorModel.monsterBehaviour.MonsterModel.hp;
            damage -= tempDamage;
        }
    }
}
