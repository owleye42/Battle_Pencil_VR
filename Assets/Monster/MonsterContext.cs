using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterContext {
	public readonly IMonsterState stateAppear = new MonsterStateAppear();
	public readonly IMonsterState stateIdle = new MonsterStateIdle();
	public readonly IMonsterState stateAction = new MonsterStateAction();
	public readonly IMonsterState stateDeath = new MonsterStateDeath();

	public MonsterContext enemyContext;

	IMonsterState currentState;

	public bool isDone = false;

	public MonsterContext() {
		BattleManager.Instance.BattleContext.AddMonster(this);
		currentState = stateAppear;
	}

	public void ExecuteUpdate() {
		currentState.ExecuteUpdate(this);
	}

	public void ChangeState(IMonsterState state) {
		currentState.ExecuteExit(this);
		currentState = state;
		currentState.ExecuteEntry(this);
	}

	public void RegisterEnemy(MonsterContext enemyContext) {
		this.enemyContext = enemyContext;
	}
}
