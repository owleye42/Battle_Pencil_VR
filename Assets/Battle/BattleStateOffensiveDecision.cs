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
		BattleManager.Instance.StartThrowPhasePencils();
	}

	public void ExecuteUpdate(BattleContext context) {
		if (BattleManager.Instance.CheckPencilsAreEnd()) {

			// 出目を検出して互いに同値ならやり直し
			if (BattleManager.Instance.CheckOutcomesDifference()) {
				BattleManager.Instance.StartThrowPhasePencils();
			}
			// ステート遷移
			else if (CheckMonsterContexts()) {
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

	bool CheckMonsterContexts() {
		if (BattleManager.Instance.playerMonsterContext != null
			&& BattleManager.Instance.computerMonsterContext != null) {
			return true;
		}

		return false;
	}
}
