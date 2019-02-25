using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// モンスターの待機ステート
/// </summary>
public class MonsterStateAttack : IState<MonsterContext>
{

    public void ExecuteEntry(MonsterContext context)
    {
        var active = BattleManager.Instance.ActiveController.OperatorModel;
        Debug.Log("[Entry] Monster State : Attack");

        active.monsterBehaviour.MonsterModel.isAttack = true;
        active.monsterBehaviour._Animator.SetTrigger("AttackTrigger");
    }

    public void ExecuteUpdate(MonsterContext context)
    {
        var anim = BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour._Animator;

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("AttackState") &&
            anim.IsInTransition(0))
        {
            BattleManager.Instance.BattleContext.isDone = true;
            context.ChangeState(context.stateIdle);
        }
    }

    public void ExecuteExit(MonsterContext context)
    {
        var nonActive = BattleManager.Instance.NonActiveController.OperatorModel;
        var active = BattleManager.Instance.ActiveController.OperatorModel;

        //nonActive.monsterBehaviour.MonsterModel.hp -=
        //    active.monsterBehaviour.MonsterModel.skillList[active.pencil.Outcome - 1].power;

        //SlowlyDecrease(nonActive, active.monsterBehaviour.MonsterModel.skillList[active.pencil.Outcome - 1].power);

        nonActive.monsterUI.SlowlyDecrease(active.monsterBehaviour.MonsterModel.skillList[active.pencil.Outcome - 1].power);

        nonActive.monsterBehaviour.MonsterModel.counterPower =
            active.monsterBehaviour.MonsterModel.skillList[active.pencil.Outcome - 1].power;

        Debug.Log("NonActiveMonsterのHP : " + nonActive.monsterBehaviour.MonsterModel.hp);

        Debug.Log("[Exit] Monster State : Attack");
    }

    //public void SlowlyDecrease(OperatorModel nonActive,int damage)
    //{
    //    while (damage != 0)
    //    {
    //        Debug.Log(damage);

    //        var tempDamage = damage / 100;
    //        if (tempDamage == 0)
    //        {
    //            tempDamage = damage % 100;
    //        }

    //        nonActive.monsterBehaviour.MonsterModel.hp -= tempDamage;
    //        Debug.Log(nonActive.monsterBehaviour.MonsterModel.hp);
    //        damage -= tempDamage;

    //        Debug.Log(damage);
    //    }
    //}
}
