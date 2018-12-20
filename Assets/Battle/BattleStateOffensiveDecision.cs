using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// バトルの攻守決定ステート
/// </summary>
public class BattleStateOffensiveDecision : IBattleState {

	bool isDecision = false;

	public void ExecuteEntry(BattleContext context) {
		Debug.Log("[Entry] Battle State : Offensive Decision");

		isDecision = false;

		BattleManager.Instance.IsThrowable = true;
		context.playerPencil.StartThrowPhase();
		context.computerPencil.StartThrowPhase();
	}

	public void ExecuteUpdate(BattleContext context) {
		if (context.playerPencil.IsEnd && context.computerPencil.IsEnd) {
			// 出目を検出して互いに同値ならやり直し
			if (context.playerPencil.Outcome == context.computerPencil.Outcome) {
				context.playerPencil.StartThrowPhase();
				context.computerPencil.StartThrowPhase();
			}
			// ステート遷移
			else if (context.InitMonsterContexts()) { 
				context.ChangeState(context.stateFight);
			}
		}
	}

	public void ExecuteExit(BattleContext context) {
		Debug.Log("[Entry] Battle State : Offensive Decision");
	}

	/// <summary>
	/// 攻守決定処理
	/// </summary>
	void DecideOffense(BattleContext context) {

		isDecision = true;
		BattleManager.Instance.IsThrowable = false;
	}
}
