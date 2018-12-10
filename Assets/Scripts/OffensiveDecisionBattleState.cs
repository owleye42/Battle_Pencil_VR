using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveDecisionBattleState : IBattleState {

	// 行動決定処理 前 の処理
	public void ExecuteEntry(BattleContext context) {
		Debug.Log("[Entry] Offensive Decision Battle State");
	}

	// 行動決定処理
	public void ExecuteUpdate(BattleContext context) {


		// ステート遷移
		var isOffensive = true;

		if (isOffensive) context.ChangeState(context.idleBattleState);
		else context.ChangeState(context.actionSelectBattleState);
	}

	// 行動決定処理 後 の処理
	public void ExecuteExit(BattleContext context) {
		Debug.Log("[Entry] Offensive Decision Battle State");
	}
}
