using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle {
	/// <summary>
	/// バトルの攻守決定ステート
	/// </summary>
	public class BattleStateOffensiveDecision : IBattleState {

		bool isDecision = false;

		public void ExecuteEntry(BattleContext context) {
			Debug.Log("[Entry] Battle State : Offensive Decision");

			isDecision = false;
		}

		public void ExecuteUpdate(BattleContext context) {

			// ステート遷移
			if (isDecision) {
				if (context.isOffense) context.ChangeState(context.stateActionSelect);
				else context.ChangeState(context.stateIdle);
			}
		}
		
		public void ExecuteExit(BattleContext context) {
			Debug.Log("[Entry] Battle State : Offensive Decision");
		}

		/// <summary>
		/// 攻守決定処理
		/// </summary>
		void DecideOffense(BattleContext context) {

			isDecision = true;
		}
	}
}