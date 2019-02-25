using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterUIController : MonoBehaviour
{
    [SerializeField]
    MonsterUIModel uiModel;

    [SerializeField]
    Sprite[] standingSprite;

    OperatorModel operatorModel;
    
    float elapsedTime = 0f;

    [Header("変化前の体力")]
    int beforeHP = 100;//初期値１００と仮定
    [Header("現在の体力バーの長さ")]
    float barLength = 1.0f;//１を初期値とする
    [Header("変更後の体力バーの長さ")]
    float afterBarLength = 1.0f;//１を初期値とする
    [Header("体力バー変更時のスピード,高ければ高いほど早くなる")]
    [SerializeField] float barSpeed;
    [Header("体力差分(確認用)")]
    [SerializeField] float difference;

    Color color;


    private void Start()
    {
        operatorModel = GetComponent<OperatorController>().OperatorModel;
        operatorModel.monsterUI = this;

        SkillSelect(0);
    }

    // 生成されるタイミングで一回呼ぶ
    public void Init()
    {
        tempHp = operatorModel.monsterBehaviour.MonsterModel.maxHP;
        uiModel.HPBar.value = uiModel.HPBar.maxValue = operatorModel.monsterBehaviour.MonsterModel.maxHP;

        uiModel.HPText.text = operatorModel.monsterBehaviour.MonsterModel.hp + " / " + operatorModel.monsterBehaviour.MonsterModel.maxHP;
        uiModel.monsterName.text = operatorModel.monsterBehaviour.MonsterModel.name;

        color = new Color(0f, 1f, 0f);
        uiModel.HPBar.transform.GetChild(1).gameObject.GetComponentInChildren<Image>().color = color;


        for (int i = 0; i < operatorModel.monsterBehaviour.MonsterModel.skillList.Count; ++i)
        {
            uiModel.skillTexts[i].name = "Skill" + i;

            // タイプによってテキスト変更
            if (operatorModel.monsterBehaviour.MonsterModel.skillList[i].skillType == SkillType.ATTACK)
            {
                uiModel.skillTexts[i].text = "あいてに" + operatorModel.monsterBehaviour.MonsterModel.skillList[i].power + "のダメージ";
            }
            else if (operatorModel.monsterBehaviour.MonsterModel.skillList[i].skillType == SkillType.SKILL)
            {
                if (operatorModel.monsterBehaviour.MonsterModel.type == Type.ATTACK)
                    uiModel.skillTexts[i].text = "あいてに" + operatorModel.monsterBehaviour.MonsterModel.skillList[i].power + "のダメージ";
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

        // モンスターのIDによって黒板の立ち絵変更
        if (operatorModel.monsterBehaviour.MonsterModel.id == 1)
            uiModel.characterImage.sprite = standingSprite[0];
        else if (operatorModel.monsterBehaviour.MonsterModel.id == 2)
            uiModel.characterImage.sprite = standingSprite[1];
        else if (operatorModel.monsterBehaviour.MonsterModel.id == 3)
            uiModel.characterImage.sprite = standingSprite[2];

        // HPbar用
        color = new Color(0f, 255f, 0f, 255f);

        barLength = 1.0f;
        afterBarLength = 1.0f;
        difference = 0f;

    }

    public void SkillSelect(int num)
    {
        if (num - 1 >= 0)
            uiModel.frame.transform.position = uiModel.skillTexts[num - 1].transform.position;
    }

    bool isDecision = false;
    public bool IsDecision { get { return isDecision; } set { isDecision = value; } }


    public void SkillDecision()
    {
        elapsedTime += Time.deltaTime;
        uiModel.frame.color = new Color(1f, 1f, 1f, Mathf.Abs(Mathf.Sin(elapsedTime * 10f)));

        if (elapsedTime >= 1f)
        {
            elapsedTime = 0f;
            uiModel.frame.color = new Color(1f, 1f, 1f, 1f);
            isDecision = false;
        }
    }

    private void Update()
    {
        if (isDecision)
        {
            SkillDecision();
        }

        //uiModel.HPText.text = operatorModel.monsterBehaviour.MonsterModel.hp + " / " + operatorModel.monsterBehaviour.MonsterModel.maxHP;
        //uiModel.HPBar.value = operatorModel.monsterBehaviour.MonsterModel.hp;

        //if (uiModel.HPBar.value > operatorModel.monsterBehaviour.MonsterModel.maxHP / 2)
        //{
        //    color.r = 0f;
        //    color.g = 255f;
        //    color.b = 0;
        //}
        //else if (uiModel.HPBar.value > operatorModel.monsterBehaviour.MonsterModel.maxHP / 4)
        //{
        //    color.r = 255f;
        //    color.g = 255f;
        //    color.b = 0f;
        //}
        //else
        //{
        //    color.r = 255f;
        //    color.g = 0f;
        //    color.b = 0f;
        //}
        //uiModel.HPBar.transform.GetChild(1).gameObject.GetComponentInChildren<Image>().color = color;//色代入
    }

    // 減少前のHP
    private int tempHp;

    float countTime = 0f;
    float nextCountTime = 1f;

    public void SlowlyDecrease(int damage)
    {
        while (damage != 0)
        {
            if (countTime >= nextCountTime)
            {
                var tempDamage = damage / 100;
                if (tempDamage == 0)
                {
                    tempDamage = damage % 100;
                }

                operatorModel.monsterBehaviour.MonsterModel.hp -= tempDamage;
                uiModel.HPText.text = operatorModel.monsterBehaviour.MonsterModel.hp + " / " + operatorModel.monsterBehaviour.MonsterModel.maxHP;
                uiModel.HPBar.value = operatorModel.monsterBehaviour.MonsterModel.hp;
                damage -= tempDamage;

                countTime = 0f;
            }
            countTime += Time.deltaTime;

            //if (uiModel.HPBar.value > operatorModel.monsterBehaviour.MonsterModel.maxHP / 2)
            //{
            //    color.r = 0f;
            //    color.g = 255f;
            //    color.b = 0;
            //}
            //else if (uiModel.HPBar.value > operatorModel.monsterBehaviour.MonsterModel.maxHP / 4)
            //{
            //    color.r = 255f;
            //    color.g = 255f;
            //    color.b = 0f;
            //}
            //else
            //{
            //    color.r = 255f;
            //    color.g = 0f;
            //    color.b = 0f;
            //}
            //uiModel.HPBar.transform.GetChild(1).gameObject.GetComponentInChildren<Image>().color = color;//色代入
        }
    }
}
