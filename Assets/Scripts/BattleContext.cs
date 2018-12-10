using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleContext {
	public readonly IBattleState initBattleState = new InitBattleState();
	public readonly IBattleState offensiveDecisionBattleState = new OffensiveDecisionBattleState();
	public readonly IBattleState idleBattleState = new OffensiveDecisionBattleState();
	public readonly IBattleState actionSelectBattleState = new OffensiveDecisionBattleState();
	public readonly IBattleState attackBattleState = new OffensiveDecisionBattleState();
	public readonly IBattleState deffensiveChangeBattleState = new OffensiveDecisionBattleState();

	IBattleState currentState = null;

	public BattleContext opponentContext;
	public bool isOffense = false;
	public bool isWaiting = false;

	/// <summary>
	/// 生成時
	/// </summary>
	public BattleContext() {
		currentState = initBattleState;
		currentState.ExecuteEntry(this);
	}

	/// <summary>
	/// 毎フレーム実行
	/// </summary>
	public void ExecuteUpdate() {
		currentState.ExecuteUpdate(this);
	}

	/// <summary>
	/// ステート遷移
	/// </summary>
	/// <param name="state">遷移先のステート</param>
	public void ChangeState(IBattleState state) {
		currentState.ExecuteExit(this);
		currentState = state;
		currentState.ExecuteEntry(this);
	}
}
