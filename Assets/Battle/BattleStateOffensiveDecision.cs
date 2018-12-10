using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle {
	/// <summary>
	/// バトルの攻守決定ステート
	/// </summary>
	public class BattleStateOffensiveDecision : IBattleState {

		bool isDecision = false;

		// ステート開始時 の処理
		public void ExecuteEntry(BattleContext context) {
			Debug.Log("[Entry] Offensive Decision Battle State");

			isDecision = false;
		}

		// ステート滞在中 の処理
		public void ExecuteUpdate(BattleContext context) {
			
			// ステート遷移
			if (isDecision) {
				if (context.isOffense) context.ChangeState(context.stateActionSelect);
				else context.ChangeState(context.stateIdle);
			}
		}

		// ステート終了時 の処理
		public void ExecuteExit(BattleContext context) {
			Debug.Log("[Entry] Offensive Decision Battle State");
		}

		// 攻守決定処理
		void OffensiveDecision() {

		}
	}
}