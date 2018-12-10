using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle {
	/// <summary>
	/// バトルの行動決定ステート
	/// </summary>
	public class BattleStateActionSelect : IBattleState {

		// ステート開始時 の処理
		public void ExecuteEntry(BattleContext context) {
			Debug.Log("[Entry] Battle State : Action Select");
		}

		// ステート滞在中 の処理
		public void ExecuteUpdate(BattleContext context) {


			// ステート遷移
			if (false)
				context.ChangeState(context.stateDoAction);
		}

		// ステート終了時 の処理
		public void ExecuteExit(BattleContext context) {
			Debug.Log("[Exit] Battle State : Action Select");
		}
	}
}