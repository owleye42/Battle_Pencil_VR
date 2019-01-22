using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// モンスターの待機ステート
/// </summary>
public class MonsterStateAttack : IState<MonsterContext> {

	public void ExecuteEntry(MonsterContext context) {
        Debug.Log("[Entry] Monster State : Attack");

        BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.MonsterAnimator.SetTrigger("AttackTrigger");
    }

	public void ExecuteUpdate(MonsterContext context) {

        if (BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.MonsterAnimator.IsInTransition(0))
        {
            context.ChangeState(context.stateIdle);
            BattleManager.Instance.SwitchAvtiveController();
            BattleManager.Instance.BattleContext.ChangeState(BattleManager.Instance.BattleContext.stateFight);
        }
	}

	public void ExecuteExit(MonsterContext context) {
        //BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.EnemyBehavior.MonsterModel.hp -=
        //    BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.MonsterModel.
        //    skillList[BattleManager.Instance.ActiveController.OperatorModel.pencil.Outcome - 1].power;

        //Debug.Log(BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.EnemyBehavior.MonsterModel.hp);
        Debug.Log("[Exit] Monster State : Attack");
    }
}
