using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle {
	public interface IBattleState {
		/// <summary>
		/// ステート開始時
		/// </summary>
		/// <param name="context"></param>
		void ExecuteEntry(BattleContext context);

		/// <summary>
		/// ステート滞在中
		/// </summary>
		/// <param name="context"></param>
		void ExecuteUpdate(BattleContext context);

		/// <summary>
		/// ステート終了時
		/// </summary>
		/// <param name="context"></param>
		void ExecuteExit(BattleContext context);
	}
}