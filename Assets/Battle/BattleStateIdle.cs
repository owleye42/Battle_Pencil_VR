using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle {
	/// <summary>
	/// バトルの待機ステート
	/// </summary>
	public class BattleStateIdle : IBattleState {

		// ステート開始時 の処理
		public void ExecuteEntry(BattleContext context) {
			Debug.Log("[Entry] Battle State : Idle");
		}

		// ステート滞在中 の処理
		public void ExecuteUpdate(BattleContext context) {


			// ステート遷移
			if (context.isOffense == true)
				context.ChangeState(context.stateActionSelect);
		}

		// ステート終了時 の処理
		public void ExecuteExit(BattleContext context) {
			Debug.Log("[Exit] Battle State : Idle");
		}
	}
}