using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// バトルの守備ステート
/// </summary>
public class BattleStateDefense : IBattleState {

	public void ExecuteEntry(BattleContext context) {
		Debug.Log("[Entry] Battle State : Defense");
	}

	public void ExecuteUpdate(BattleContext context) {

	}

	public void ExecuteExit(BattleContext context) {
		Debug.Log("[Exit] Battle State : Defense");
	}
}
