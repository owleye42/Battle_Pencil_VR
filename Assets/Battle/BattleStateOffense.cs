using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// バトルの攻撃ステート
/// </summary>
public class BattleStateOffense : IBattleState {

	public void ExecuteEntry(BattleContext context) {
		Debug.Log("[Entry] Battle State : Offense");
	}

	public void ExecuteUpdate(BattleContext context) {

	}

	public void ExecuteExit(BattleContext context) {
		Debug.Log("[Exit] Battle State : Offense");
	}
}
