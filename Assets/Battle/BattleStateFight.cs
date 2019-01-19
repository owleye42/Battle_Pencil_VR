using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// バトルの戦闘ステート
/// </summary>
public class BattleStateFight : IState<BattleContext> {

	bool isEnd = false;

	public void IsEnd(bool b) { isEnd = b; }

	public void ExecuteEntry(BattleContext context) {
		Debug.Log("[Entry] Battle State : Fight");

		BattleManager.Instance.StartThrowActiveController();
	}

	public void ExecuteUpdate(BattleContext context) {

		if (isEnd) {
			context.ChangeState(context.stateResult);
			return;
		}

		if (context.isDone) {
			context.ChangeState(context.stateFight);
		}
	}

	public void ExecuteExit(BattleContext context) {
		Debug.Log("[Exit] Battle State : Fight");

		BattleManager.Instance.StartWaitActiveController();
		BattleManager.Instance.SwitchAvtiveController();
	}
}
