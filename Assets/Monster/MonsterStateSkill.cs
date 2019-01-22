using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///モンスターのスキルステート
/// </summary>>

public class MonsterStateSkill : IState<MonsterContext> {

    public void ExecuteEntry(MonsterContext context)
    {
        Debug.Log("[Entry] Monster State : Skill");

        BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.MonsterAnimator.SetTrigger("SkillTrigger");
    }

    public void ExecuteUpdate(MonsterContext context)
    {
        if (BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.MonsterAnimator.IsInTransition(0))
        {
            context.ChangeState(context.stateIdle);
            BattleManager.Instance.BattleContext.isDone = true;
        }
    }

    public void ExecuteExit(MonsterContext context)
    {
        //if (BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.MonsterModel.type == Type.ATTACK) {
        //    BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.EnemyBehavior.MonsterModel.hp -=
        //    BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.MonsterModel.
        //    skillList[BattleManager.Instance.ActiveController.OperatorModel.pencil.Outcome - 1].power;
        //}else if (BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.MonsterModel.type == Type.DEFENCE) {

        //}else if (BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.MonsterModel.type == Type.HEAL) {
        //    BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.MonsterModel.hp +=
        //    BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.MonsterModel.
        //    skillList[BattleManager.Instance.ActiveController.OperatorModel.pencil.Outcome - 1].power;
        //}


        Debug.Log("[Exit] Monster State : Skill");
    }
}
