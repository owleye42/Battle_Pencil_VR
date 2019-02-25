using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// バトルの結果ステート
/// </summary>
public class BattleStateResult : IState<BattleContext> {

	public void ExecuteEntry(BattleContext context) {
		Debug.LogWarning("[Entry] Battle State : Result");

		// キャンバス切り替え

	}

	public void ExecuteUpdate(BattleContext context) {
		if (context.isDone) {

		}
	}

	public void ExecuteExit(BattleContext context) {
		Debug.LogWarning("[Exit] Battle State : Result");
	}
}