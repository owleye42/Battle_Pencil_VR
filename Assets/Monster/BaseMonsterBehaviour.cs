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

	Transform standingTransform;

	void Awake() {
		monsterContext = new MonsterContext();

		if (isPlayer) {
			BattleManager.Instance.playerMonsterBehaviour = this;
			BattleManager.Instance.playerMonsterContext = monsterContext;
		}
		else {
			BattleManager.Instance.computerMonsterBehaviour = this;
			BattleManager.Instance.computerMonsterContext = monsterContext;
		}
	}

	void Start() {
		//monsterContext = new MonsterContext();

		//ActionSelect(Random.Range(0, 6));
	}

	void Update() {

	}

	public void ActionSelect(int skill_id) {
		if (monsterModel.skillList[skill_id].skillType == SkillType.Attack) {
			EnemyBehavior.monsterModel.hp -= monsterModel.skillList[skill_id].power;
			Debug.Log(EnemyBehavior.monsterModel.hp);
		}
		else if (monsterModel.skillList[skill_id].skillType == SkillType.Heal) {
			monsterModel.hp += monsterModel.skillList[skill_id].power;
			Debug.Log(monsterModel.hp);
		}
		else if (monsterModel.skillList[skill_id].skillType == SkillType.Miss) {
			Debug.Log("MISS!!!!!!!!!!!!!!!!");
		}
	}
}
