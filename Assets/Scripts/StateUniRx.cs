using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// UniRx を利用したステートマシン
/// 実行順は Entry -> Update(ループ) -> Exit
/// </summary>
public abstract class UniRxState<T> {
	public readonly Subject<Unit> EntrySubject = new Subject<Unit>();
	public readonly Subject<Unit> UpdateSubject = new Subject<Unit>();
	public readonly Subject<Unit> ExitSubject = new Subject<Unit>();

	/// <summary>
	/// ステート開始時に実行
	/// </summary>
	/// <param name="context"></param>
	public virtual void ExecuteEntry(T context) {
		EntrySubject.OnNext(Unit.Default);
	}

	/// <summary>
	/// ステート滞在中に実行
	/// </summary>
	/// <param name="context"></param>
	public virtual void ExecuteUpdate(T context) {
		UpdateSubject.OnNext(Unit.Default);
	}

	/// <summary>
	/// ステート終了時に実行
	/// </summary>
	/// <param name="context"></param>
	public virtual void ExecuteExit(T context) {
		ExitSubject.OnNext(Unit.Default);
	}
}