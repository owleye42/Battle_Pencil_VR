using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonsterBehaviour : MonoBehaviour {

	[SerializeField]
	MonsterModel monsterModel;
	public MonsterModel MonsterModel { get { return monsterModel; } }

	public BaseMonsterBehaviour EnemyBehavior;

	public bool isPlayer = false;

	MonsterContext monsterContext = null;

    public bool isCounter = false;

	void Awake() {
		if (isPlayer)
			BattleManager.Instance.playerMonsterBehaviour = this;
		else
			BattleManager.Instance.computerMonsterBehaviour = this;
	}

	void Start() {
		//monsterContext = new MonsterContext();

		//ActionSelect(Random.Range(0, 6));
	}

	void Update() {

	}

	public void ActionSelect(int skill_id) {
        isCounter = false;

		if (monsterModel.skillList[skill_id].skillType == SkillType.Attack) {
            if(EnemyBehavior.isCounter && monsterModel.skillList[skill_id].power >= 40){
                monsterModel.hp -= EnemyBehavior.monsterModel.skillList[skill_id].power;
                Debug.Log(monsterModel.hp);
            }
            else{
			EnemyBehavior.monsterModel.hp -= monsterModel.skillList[skill_id].power;
			Debug.Log(EnemyBehavior.monsterModel.hp);
            }
		}
        else if(monsterModel.skillList[skill_id].skillType == SkillType.Heal) {
			monsterModel.hp += monsterModel.skillList[skill_id].power;
			Debug.Log(monsterModel.hp);
		}
        else if(monsterModel.skillList[skill_id].skillType == SkillType.Counter){
            isCounter = true;
        }
		else if (monsterModel.skillList[skill_id].skillType == SkillType.Miss) {
			Debug.Log("MISS!!!!!!!!!!!!!!!!");
		}
    }
}
