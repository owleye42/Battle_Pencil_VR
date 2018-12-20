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

	public MonsterContext playerMonsterContext = null;
	public MonsterContext computerMonsterContext = null;

	public Pencil playerPencil = null;
	public Pencil computerPencil = null;

	/// <summary>
	/// 生成時
	/// </summary>
	public BattleContext() {
		CurrentState = stateInit;
		CurrentState.ExecuteEntry(this);
	}

	public bool InitPencils() {
		if (playerPencil == null)
			playerPencil = BattleManager.Instance.playerPencil;
		if (computerPencil == null)
			computerPencil = BattleManager.Instance.computerPencil;

		if(playerPencil != null && computerPencil != null) {
			return true;
		}

		return false;
	}

	public bool InitMonsterContexts() {
		if (playerMonsterContext == null)
			playerMonsterContext = BattleManager.Instance.playerMonsterContext;
		if (computerMonsterContext == null)
			computerMonsterContext = BattleManager.Instance.computerMonsterContext;

		if (playerMonsterContext != null && computerMonsterContext != null) {
			return true;
		}

		return false;
	}

	/// <summary>
	/// 滞在中のステートの ExecuteUpdate() を実行
	/// モンスターのコンテキストの ExecuteUpdate() を実行
	/// </summary>
	public void ExecuteUpdate() {
		CurrentState.ExecuteUpdate(this);

		if (playerMonsterContext != null)
			playerMonsterContext.ExecuteUpdate();

		if (computerMonsterContext != null)
			computerMonsterContext.ExecuteUpdate();
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
}
