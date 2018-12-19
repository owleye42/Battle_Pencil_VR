using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// バトルの初期化ステート
/// </summary>
public class BattleStateInit : IBattleState {

	float elapsedTime = 0;

	public void ExecuteEntry(BattleContext context) {
		Debug.Log("[Entry] Battle State : Init");
		elapsedTime = 0;
	}

	public void ExecuteUpdate(BattleContext context) {
		elapsedTime += Time.deltaTime;

		if(elapsedTime > 3) {
			Debug.Log("初期化ステート 3秒経過");

			// 攻守決定ステートへ遷移
			context.ChangeState(context.stateOffensiveDecision);
		}
	}

	public void ExecuteExit(BattleContext context) {
		Debug.Log("[Exit] Battle State : Init");
	}

	/// <summary>
	/// 初期化処理
	/// </summary>
	void Init() {

	}
}