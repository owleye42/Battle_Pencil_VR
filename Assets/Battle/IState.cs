using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 実行順は Entry -> Update(ループ) -> Exit
/// </summary>
public interface IState<T> {
	/// <summary>
	/// ステート開始時に実行
	/// </summary>
	/// <param name="context"></param>
	void ExecuteEntry(T context);

	/// <summary>
	/// ステート滞在中に実行
	/// </summary>
	/// <param name="context"></param>
	void ExecuteUpdate(T context);

	/// <summary>
	/// ステート終了時に実行
	/// </summary>
	/// <param name="context"></param>
	void ExecuteExit(T context);
}
