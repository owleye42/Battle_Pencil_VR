using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle {
	/// <summary>
	/// バトルの初期化ステート
	/// </summary>
	public class BattleStateInit : IBattleState {

		// ステート開始時 の処理
		public void ExecuteEntry(BattleContext context) {
			Debug.Log("[Entry] Init Battle State");
		}

		// ステート滞在中 の処理
		public void ExecuteUpdate(BattleContext context) {


			// ステート遷移
			// 攻守決定ステートへ遷移
			if (context.enemyContexts != null && context.enemyContexts.Count > 0)
				context.ChangeState(context.stateOffensiveDecision);
		}

		// ステート終了時 の処理
		public void ExecuteExit(BattleContext context) {
			Debug.Log("[Exit] Init Battle State");
		}
	}
}