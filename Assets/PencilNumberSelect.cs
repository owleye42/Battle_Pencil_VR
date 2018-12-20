using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PencilNumberSelect : MonoBehaviour
{
    [SerializeField]
    Transform grid;

    [SerializeField]
    Text[] child;

    [SerializeField]
    Image image = null;


    float arrayNum;
    [SerializeField]
    float speed = 50f;

    

    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < child.Length; ++i)
        {
            child[i].name = "Skill" + i;
        }

        SkillText(BattleManager.Instance.computerMonsterBehaviour.MonsterModel.skillList);
    }

    // Update is called once per frame
    void Update()
    {
        SkillRotate();
        //SkillDecision();
    }

    public void SkillText(List<SkillModel> skillModels)
    {
        for (int i = 0; i < skillModels.Count; ++i)
            child[i].text = skillModels[i].text;
    }

    public void SkillRotate()
    {
        arrayNum += speed * Time.deltaTime;
        if (arrayNum >= child.Length)
            arrayNum = 0;

        //image.transform.position = child[(int)arrayNum].transform.position;
    }

    public void SkillDecision()
    {
        //image.color = new Color(1, 1, 1, Mathf.Clamp(Mathf.Cos(30f * Time.time), 0f, 1f));
    }
}
