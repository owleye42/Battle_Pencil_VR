using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class BaseMonsterBehaviour : MonoBehaviour
    {

        [SerializeField]
        MonsterModel monsterModel;
        public MonsterModel Model { get { return monsterModel; } }
        public BaseMonsterBehaviour EnemyBehavior { set; get; }

        int random;

        void Awake()
        {
            
        }

        void Start()
        {
            random = Random.Range(0, 6);
        }

        void Update()
        {
            ActionSelect();
        }

        public void ActionSelect()
        {
            if (monsterModel.skillList[random].skillType == SkillType.Attack)
            {
                EnemyBehavior.monsterModel.hp -= monsterModel.skillList[random].power;
                Debug.Log(EnemyBehavior.monsterModel.hp);
            }
            else if (monsterModel.skillList[random].skillType == SkillType.Heal)
            {
                monsterModel.hp += monsterModel.skillList[random].power;
                Debug.Log(monsterModel.hp);
            }
            else if (monsterModel.skillList[random].skillType == SkillType.Miss)
            {
                Debug.Log("MISS!!!!!!!!!!!!!!!!");
            }
        }
    }
}