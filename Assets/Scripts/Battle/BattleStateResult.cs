using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// バトルの結果ステート
/// </summary>
public class BattleStateResult : IState<BattleContext> {

	int stayTime = 10 * 60;

	public void ExecuteEntry(BattleContext context) {
		Debug.LogWarning("[Entry] Battle State : Result");

		// キャンバス切り替え
		BlackBoardManager.Instance.ChangeCanvas(BlackBoardManager.ECanvasType.Result);
	}

	public void ExecuteUpdate(BattleContext context) {
		if (stayTime <= 0) {
			context.ChangeState(context.stateWait);
		}

		stayTime--;
	}

	public void ExecuteExit(BattleContext context) {
		Debug.LogWarning("[Exit] Battle State : Result");

		MySceneManager.Instance.ChangeScene(MySceneManager.ESceneType.Title);
	}
}