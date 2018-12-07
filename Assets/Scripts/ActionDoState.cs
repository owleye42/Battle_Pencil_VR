using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDoState : IActionState {

	public void ExecuteEntry(ActionContext context) {
		// 行動前 の処理
	}

	public void ExecuteUpdate(ActionContext context) {
		// 行動時の 処理


		// ステート遷移
		if (true) context.ChangeState(context.actionResultState);
	}

	public void ExecuteExit(ActionContext context) {
		// 行動後 の処理

	}
}
