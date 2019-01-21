using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// モンスターの待機ステート
/// モンスターの待機アニメーション
/// サイコロの出目が決まったら次のステートへ
/// </summary>
public class MonsterStateIdle : IState<MonsterContext> {

	public void ExecuteEntry(MonsterContext context) {

	}

	public void ExecuteUpdate(MonsterContext context) {
        if (BattleManager.Instance.ActiveController.OperatorModel.pencil.Outcome == SkillType.Attack)
        {
            context.ChangeState(context.stateAttack);
        }
        else if ()
        {
            context.ChangeState(context.stateCounter);
        }
        else if ()
        {
            context.ChangeState(context.stateHeal);
        }

    }

	public void ExecuteExit(MonsterContext context) {

	}
}
