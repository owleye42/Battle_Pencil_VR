using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionResult : IActionState {

	public void ExecuteEntry(ActionContext context) {
		// 判定前 の処理
	}

	public void ExecuteUpdate(ActionContext context) {
		// 判定時の 処理


		// ステート遷移
		if (true) context.ChangeState(context.actionShiftState);
	}

	public void ExecuteExit(ActionContext context) {
		// 判定後 の処理

	}
}
