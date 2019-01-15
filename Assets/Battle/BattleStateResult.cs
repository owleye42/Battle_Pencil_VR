using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// バトルの結果ステート
/// </summary>
public class BattleStateResult : IState<BattleContext> {

	public void ExecuteEntry(BattleContext context) {
		Debug.Log("[Entry] Battle State : Result");
	}

	public void ExecuteUpdate(BattleContext context) {

	}

	public void ExecuteExit(BattleContext context) {
		Debug.Log("[Exit] Battle State : Result");
	}
}