using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのステートを操作するクラス
/// </summary>
public class OperatorContext {
	public readonly IState<OperatorContext> stateInit = new OperatorStateInit();
	public readonly IState<OperatorContext> stateWait = new OperatorStateWait();
	public readonly IState<OperatorContext> stateThrow = new OperatorStateThrow();
	public readonly IState<OperatorContext> stateEnd = new OperatorStateEnd();

	public IState<OperatorContext> CurrentState { get; private set; }

	public OperatorController OperatorController { get; set; }

	public bool isDone = false;
	public int timeLimit;

	/// <summary>
	/// 生成時
	/// </summary>
	public OperatorContext(int timeLimit) {
		this.timeLimit = timeLimit;
		CurrentState = stateInit;
		CurrentState.ExecuteEntry(this);
	}

	/// <summary>
	/// 滞在中のステートの ExecuteUpdate() を実行
	/// </summary>
	public void ExecuteUpdate() {
		CurrentState.ExecuteUpdate(this);
	}

	/// <summary>
	/// ステート遷移
	/// </summary>
	/// <param name="state">遷移先のステート</param>
	public void ChangeState(IState<OperatorContext> state) {
		CurrentState.ExecuteExit(this);
		CurrentState = state;
		isDone = false;
		CurrentState.ExecuteEntry(this);
	}

	public void ToResult() {
		ChangeState(stateEnd);
	}
}
