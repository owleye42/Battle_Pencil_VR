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
	}

	public void ExecuteUpdate(BattleContext context) {

		// 全ての処理が終わっていないなら
		if (!context.isDone) {

			// 互いの出目が異値なら
			if (BattleManager.Instance.CheckOutcomesAreDifferent()) {

				// 両者のモンスターを召喚
				BattleManager.Instance.SummonMonsters();

				// n秒後にステート遷移
				Observable.Timer(TimeSpan.FromSeconds(3)).Subscribe(_ =>
					context.ChangeState(context.stateFight)
				);

				context.isDone = true;
			}
		}
	}

	public void ExecuteExit(BattleContext context) {
		Debug.Log("[Entry] Battle State : Offensive Decision");
	}
}
