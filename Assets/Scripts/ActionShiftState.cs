using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionShiftState : IActionState {

	public void ExecuteEntry(ActionContext context) {
		// 攻守交替前 の処理

	}

	public void ExecuteUpdate(ActionContext context) {
		// 攻守交替時の 処理


		// ステート遷移
		if (true) context.ChangeState(context.actionReadyState);
	}

	public void ExecuteExit(ActionContext context) {
		// 攻守交替後 の処理

	}
}
