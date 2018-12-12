using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle {
	/// <summary>
	/// 実行順は Entry -> Update(ループ) -> Exit
	/// </summary>
	public interface IBattleState {
		/// <summary>
		/// ステート開始時に実行
		/// </summary>
		/// <param name="context"></param>
		void ExecuteEntry(BattleContext context);

		/// <summary>
		/// ステート滞在中に実行
		/// </summary>
		/// <param name="context"></param>
		void ExecuteUpdate(BattleContext context);

		/// <summary>
		/// ステート終了時に実行
		/// </summary>
		/// <param name="context"></param>
		void ExecuteExit(BattleContext context);
	}
}