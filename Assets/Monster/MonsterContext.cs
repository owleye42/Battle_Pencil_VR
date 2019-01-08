using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterContext {
	public readonly IMonsterState stateAppear = new MonsterStateAppear();
	public readonly IMonsterState stateIdle = new MonsterStateIdle();
	public readonly IMonsterState stateAction = new MonsterStateAction();
	public readonly IMonsterState stateDeath = new MonsterStateDeath();

	public readonly IMonsterState stateOffense = new MonsterStateDeath();
	public readonly IMonsterState stateDefense = new MonsterStateDeath();

	IMonsterState currentState;

	public bool isPlayerMosnter = false;
	public bool isDone = false;

	public MonsterContext() {
		if (isPlayerMosnter)
			BattleManager.Instance.playerMonsterContext = this;
		else
			BattleManager.Instance.computerMonsterContext = this;

		currentState = stateAppear;
		currentState.ExecuteEntry(this);
	}

	public void ExecuteUpdate() {
		currentState.ExecuteUpdate(this);
	}

	public void ChangeState(IMonsterState state) {
		currentState.ExecuteExit(this);
		currentState = state;
		isDone = false;
		currentState.ExecuteEntry(this);
	}
}
