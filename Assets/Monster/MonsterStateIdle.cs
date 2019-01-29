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
        Debug.Log("[Entry] Monster State : Idol");
        
    }

	public void ExecuteUpdate(MonsterContext context) {
        //Debug.Log(BattleManager.Instance.ActiveController.OperatorModel.pencil.Outcome);
        if (BattleManager.Instance.ActiveController.OperatorModel.pencil.Outcome == 0) return;


        // ActiveControllerの中のスキルタイプによって行動変更
        if(BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.MonsterModel.
            skillList[BattleManager.Instance.ActiveController.OperatorModel.pencil.Outcome - 1].skillType == SkillType.ATTACK){
            context.ChangeState(context.stateAttack);
        }
		else if(BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.MonsterModel.
            skillList[BattleManager.Instance.ActiveController.OperatorModel.pencil.Outcome - 1].skillType == SkillType.SKILL) {
            context.ChangeState(context.stateSkill);
        }
		else if(BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.MonsterModel.
            skillList[BattleManager.Instance.ActiveController.OperatorModel.pencil.Outcome - 1].skillType == SkillType.MISS) {
            Debug.Log("MISS");
        }

    }

	public void ExecuteExit(MonsterContext context) {
        Debug.Log("[Exit] Monster State : Idol");
    }
}
