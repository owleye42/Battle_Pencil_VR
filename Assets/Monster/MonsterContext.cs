using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterContext {
	public readonly IState<MonsterContext> stateAppear = new MonsterStateAppear();
	public readonly IState<MonsterContext> stateIdle = new MonsterStateIdle();
	public readonly IState<MonsterContext> stateAttack = new MonsterStateAttack();
    public readonly IState<MonsterContext> stateSkill = new MonsterStateSkill();
    public readonly IState<MonsterContext> stateDeath = new MonsterStateDeath();

	IState<MonsterContext> currentState;

	public bool isDone = false;

	public MonsterContext() {
		currentState = stateAppear;
		currentState.ExecuteEntry(this);
	}

	public void ExecuteUpdate() {
		currentState.ExecuteUpdate(this);
	}

	public void ChangeState(IState<MonsterContext> state) {
		currentState.ExecuteExit(this);
		currentState = state;
		isDone = false;
		currentState.ExecuteEntry(this);
	}
}