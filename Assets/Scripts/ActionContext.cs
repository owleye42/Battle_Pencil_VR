using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionContext {
	public readonly IActionState actionInitState = new ActionInitState();
	public readonly IActionState actionReadyState = new ActionReadyState();
	public readonly IActionState actionSelectState = new ActionSelectState();
	public readonly IActionState actionDoState = new ActionDoState();
	public readonly IActionState actionResultState = new ActionResult();
	public readonly IActionState actionShiftState = new ActionShiftState();

	IActionState currentState = null;

	public ActionContext() {
		currentState = actionSelectState;
		currentState.ExecuteEntry(this);
	}

	public void ExecuteUpdate() {
		currentState.ExecuteUpdate(this);
	}

	public void ChangeState(IActionState state) {
		currentState.ExecuteExit(this);
		currentState = state;
		currentState.ExecuteEntry(this);
	}
}
