using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle {
	/// <summary>
	/// バトルの初期化ステート
	/// </summary>
	public class BattleStateInit : IBattleState {

		public void ExecuteEntry(BattleContext context) {
			Debug.Log("[Entry] Battle State : Init");

			// 攻守決定ステートへ遷移
			context.ChangeState(context.stateOffensiveDecision);
		}

		public void ExecuteUpdate(BattleContext context) {

		}

		public void ExecuteExit(BattleContext context) {
			Debug.Log("[Exit] Battle State : Init");
		}

		/// <summary>
		/// 初期化処理
		/// </summary>
		void Init() {

		}
	}
}