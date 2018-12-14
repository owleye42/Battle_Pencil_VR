using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle {
	/// <summary>
	/// バトルの行動実行ステート
	/// </summary>
	public class BattleStateDoAction : IBattleState {

		// 他ステートからの遷移直後 の処理
		public void ExecuteEntry(BattleContext context) {
			Debug.Log("[Entry] Battle State : Do Action");
		}

		// ステート滞在中 の処理
		public void ExecuteUpdate(BattleContext context) {


			// ステート遷移
			if (true)
				context.ChangeState(context.stateIdle);
		}

		// 他ステートへの遷移直前 の処理
		public void ExecuteExit(BattleContext context) {
			Debug.Log("[Exit] Battle State : Do Action");
		}
	}
}