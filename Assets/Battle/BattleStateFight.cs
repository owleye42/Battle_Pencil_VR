using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// バトルの戦闘ステート
/// </summary>
public class BattleStateFight : IBattleState {

	bool isEndGame = false;

	public void ExecuteEntry(BattleContext context) {
		Debug.Log("[Entry] Battle State : Fight");

		isEndGame = false;
	}

	public void ExecuteUpdate(BattleContext context) {


		if (isEndGame == true) context.ChangeState(context.stateResult);
	}

	public void ExecuteExit(BattleContext context) {
		Debug.Log("[Exit] Battle State : Fight");
	}
}
