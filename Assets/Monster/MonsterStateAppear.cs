using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// モンスターの待機ステート
/// </summary>
public class MonsterStateAppear : IState<MonsterContext> {

	public void ExecuteEntry(MonsterContext context) {

	}

	public void ExecuteUpdate(MonsterContext context) {
        context.ChangeState(context.stateIdle);
	}

	public void ExecuteExit(MonsterContext context) {

	}
}
