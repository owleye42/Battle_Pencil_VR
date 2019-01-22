using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// バトルの戦闘ステート
/// </summary>
public class BattleStateFight : IState<BattleContext> {

	bool isEnd = false;

	public void IsEnd(bool b) { isEnd = b; }

	int count = 600;

	public void ExecuteEntry(BattleContext context) {
		Debug.Log("[Entry] Battle State : Fight");
        BattleManager.Instance.IsFight = true;

		BattleManager.Instance.StartThrowActiveController();

		count = 600;
	}

	public void ExecuteUpdate(BattleContext context) {

		if (isEnd) {
			context.ChangeState(context.stateResult);
			return;
		}

		if (count == 0) {
			BattleManager.Instance.ForceThrowPencil();
		}

		if (context.isDone) {
			BattleManager.Instance.SwitchAvtiveController();
			context.ChangeState(context.stateFight);
		}

		count--;
	}

	public void ExecuteExit(BattleContext context) {
        BattleManager.Instance.IsFight = false;

        Debug.Log("[Exit] Battle State : Fight");
	}
}
