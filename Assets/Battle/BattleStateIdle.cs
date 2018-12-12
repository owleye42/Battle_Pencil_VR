using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle {
	/// <summary>
	/// バトルの待機ステート
	/// </summary>
	public class BattleStateIdle : IBattleState {

		public void ExecuteEntry(BattleContext context) {
			Debug.Log("[Entry] Battle State : Idle");
		}

		public void ExecuteUpdate(BattleContext context) {

		}

		public void ExecuteExit(BattleContext context) {
			Debug.Log("[Exit] Battle State : Idle");
		}
	}
}