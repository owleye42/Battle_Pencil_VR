using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 実行順は Entry -> Update(ループ) -> Exit
/// </summary>
public interface IMonsterState {
	/// <summary>
	/// ステート開始時に実行
	/// </summary>
	/// <param name="context"></param>
	void ExecuteEntry(MonsterContext context);

	/// <summary>
	/// ステート滞在中に実行
	/// </summary>
	/// <param name="context"></param>
	void ExecuteUpdate(MonsterContext context);

	/// <summary>
	/// ステート終了時に実行
	/// </summary>
	/// <param name="context"></param>
	void ExecuteExit(MonsterContext context);
}
