using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionReadyState : IActionState {

	public void ExecuteEntry(ActionContext context) {
		// 待機前 の処理
	}

	public void ExecuteUpdate(ActionContext context) {
		// 待機時 の処理


		// ステート遷移
		if (true) context.ChangeState(context.actionSelectState);
	}

	public void ExecuteExit(ActionContext context) {
		// 待機後 の処理

	}
}
