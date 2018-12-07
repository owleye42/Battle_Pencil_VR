using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelectState : IActionState {

	public void ExecuteEntry(ActionContext context) {
		// 鉛筆を転がす前 の処理
	}

	public void ExecuteUpdate(ActionContext context) {
		// 鉛筆を転がっているときの 処理


		// ステート遷移
		if (true) context.ChangeState(context.actionDoState);
	}

	public void ExecuteExit(ActionContext context) {
		// 鉛筆を転がした後 の処理

	}
}
