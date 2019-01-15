using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

/// <summary>
/// バトルの攻守決定ステート
/// </summary>
public class BattleStateOffensiveDecision : IState<BattleContext> {

	public void ExecuteEntry(BattleContext context) {
		Debug.Log("[Entry] Battle State : Offensive Decision");

		BattleManager.Instance.StartThrowPhaseEachPencil();
	}

	public void ExecuteUpdate(BattleContext context) {

		// まだ実行されておらず
		// 互いの出目異値なら
		if (!context.isDone && BattleManager.Instance.CheckOutcomesAreDifferent()) {

			// 両者のモンスターを召喚
			BattleManager.Instance.SummonMonsters();

			// 3秒後にステート遷移
			Observable.Timer(TimeSpan.FromMilliseconds(1000)).Subscribe(_ =>
				context.ChangeState(context.stateFight)
			);
		}
	}

	public void ExecuteExit(BattleContext context) {
		Debug.Log("[Entry] Battle State : Offensive Decision");
	}
}
