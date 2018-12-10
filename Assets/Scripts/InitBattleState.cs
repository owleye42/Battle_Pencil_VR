using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBattleState : IBattleState {

	bool isCompleted = false;

	// 初期化処理 前 の処理
	public void ExecuteEntry(BattleContext context) {
		Debug.Log("[Entry] Init Battle State");
	}

	// 初期化処理
	public void ExecuteUpdate(BattleContext context) {


		// ステート遷移
		// 
		if (context.opponentContext != null)
			context.ChangeState(context.offensiveDecisionBattleState);
	}

	// 初期化処理 後 の処理
	public void ExecuteExit(BattleContext context) {
		Debug.Log("[Exit] Init Battle State");
	}
}
