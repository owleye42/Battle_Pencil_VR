using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// バトルの初期化ステート
/// </summary>
public class BattleStateInit : IState<BattleContext> {

	public void ExecuteEntry(BattleContext context) {
		Debug.LogWarning("[Entry] Battle State : Init");
	}

	public void ExecuteUpdate(BattleContext context) {

		// 初期化完了したなら
		if (Init()) {
			// 攻守決定ステートへ遷移
			context.ChangeState(context.stateFight);
		}
	}

	public void ExecuteExit(BattleContext context) {
		Debug.LogWarning("[Exit] Battle State : Init");

		OperatorManager.Instance.PlayerController.OperatorModel.pencil.SummonMonster();
		OperatorManager.Instance.ComputerController.OperatorModel.pencil.SummonMonster();
	}

	/// <summary>
	/// 初期化処理
	/// </summary>
	bool Init() {

		if (BattleManager.Instance.ActiveController != null && BattleManager.Instance.NonActiveController != null) {


			return true;
		}
		if (OperatorManager.Instance.PlayerController != null) {
			BattleManager.Instance.ActiveController = OperatorManager.Instance.PlayerController;
		}
		if (OperatorManager.Instance.ComputerController != null) { 
			BattleManager.Instance.NonActiveController = OperatorManager.Instance.ComputerController;
        }

		return false;
	}
}