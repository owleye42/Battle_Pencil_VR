using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleContext {
	public readonly IBattleState stateInit = new BattleStateInit();
	public readonly IBattleState stateOffensiveDecision = new BattleStateOffensiveDecision();
	public readonly IBattleState stateFight = new BattleStateFight();
	public readonly IBattleState stateResult = new BattleStateResult();

	public IBattleState CurrentState { get; private set; }

	List<MonsterContext> monsterContexts = new List<MonsterContext>();

	/// <summary>
	/// 生成時
	/// </summary>
	public BattleContext() {
		CurrentState = stateInit;
		CurrentState.ExecuteEntry(this);
	}

	/// <summary>
	/// 滞在中のステートの ExecuteUpdate() を実行
	/// モンスターのコンテキストの ExecuteUpdate() を実行
	/// </summary>
	public void ExecuteUpdate() {
		CurrentState.ExecuteUpdate(this);

		if(monsterContexts != null && monsterContexts.Count > 0)
			monsterContexts.ForEach(monsterContext => monsterContext.ExecuteUpdate());
	}

	/// <summary>
	/// ステート遷移
	/// </summary>
	/// <param name="state">遷移先のステート</param>
	public void ChangeState(IBattleState state) {
		CurrentState.ExecuteExit(this);
		CurrentState = state;
		CurrentState.ExecuteEntry(this);
	}

	public void AddMonster(MonsterContext monsterContext) {
		monsterContexts.Add(monsterContext);
	}
}
