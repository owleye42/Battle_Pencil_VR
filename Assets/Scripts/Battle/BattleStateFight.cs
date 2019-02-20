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
		Debug.LogWarning("[Entry] Battle State : Fight");
		
		OperatorManager.Instance.PlayerController.OperatorModel.pencil.SummonMonster();
		OperatorManager.Instance.ComputerController.OperatorModel.pencil.SummonMonster();

		BattleManager.Instance.StartThrowActiveController();
        
		count = 600;
	}

	public void ExecuteUpdate(BattleContext context) {

        if (BattleManager.Instance.ActiveController.OperatorModel.pencil.Outcome != 0)
        {
            BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.MonsterContext.ExecuteUpdate();
        }

		if (isEnd) {
			context.ChangeState(context.stateResult);
			return;
		}

		// 行動終了時
		if (context.isDone) {
            context.ChangeState(context.stateFight);
		}

		count--;
	}

	public void ExecuteExit(BattleContext context) {
        BattleManager.Instance.SwitchAvtiveController();

        Debug.LogWarning("[Exit] Battle State : Fight");
	}
}
