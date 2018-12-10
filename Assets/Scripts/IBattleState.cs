using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleState {
	void ExecuteEntry(BattleContext context);
	void ExecuteUpdate(BattleContext context);
	void ExecuteExit(BattleContext context);
}
