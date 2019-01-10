using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PencilNumberSelect : MonoBehaviour
{
    [SerializeField]
    Text[] playerSkills;
    public Text[] PlayerSkills { get { return playerSkills; } }
    [SerializeField]
    Image playerFrame;


    [SerializeField]
    Text[] enemySkills;
    public Text[] EnemySkills { get { return enemySkills; } }
    [SerializeField]
    Image enemyFrame;

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
    public void SkillText(Text[] skillTexts, List<SkillModel> skillModels)
    {
        for (int i = 0; i < skillModels.Count; ++i)
        {
            skillTexts[i].name = "Skill" + i;
            skillTexts[i].text = skillModels[i].text;
        }
    }


    public void SkillSelect(Text[] skillTexts, int num)
    {
        playerFrame.transform.position = skillTexts[num].transform.position;
    }

    public void SkillDecision()
    {
        //image.color = new Color(1, 1, 1, Mathf.Clamp(Mathf.Cos(30f * Time.time), 0f, 1f));
    }
}
