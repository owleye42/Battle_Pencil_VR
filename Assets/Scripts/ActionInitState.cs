using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionInitState : IActionState {

	public void ExecuteEntry(ActionContext context) {
		// 初期化前 の処理

	}

	public void ExecuteUpdate(ActionContext context) {
		// 初期化時 の処理


		// ステート遷移
		if (true) context.ChangeState(context.actionReadyState);
	}

	public void ExecuteExit(ActionContext context) {
		// 初期化後 の処理

	}
}
