using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionState {
	void ExecuteEntry(ActionContext context);
	void ExecuteUpdate(ActionContext context);
	void ExecuteExit(ActionContext context);
}
