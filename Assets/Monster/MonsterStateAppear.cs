using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// モンスターの待機ステート
/// </summary>
public class MonsterStateAppear : IMonsterState {

	public void ExecuteEntry(MonsterContext context) {
		context.isDone = false;
	}

	public void ExecuteUpdate(MonsterContext context) {


		if (context.isDone) {
			context.ChangeState(context.stateIdle);
		}
	}

	public void ExecuteExit(MonsterContext context) {

	}
}
