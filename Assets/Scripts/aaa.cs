using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour
{
    public void AttackState()
    {
        BattleManager.Instance.NonActiveController.OperatorModel.monsterBehaviour.MonsterModel.hp -=
            BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.MonsterModel.
            skillList[BattleManager.Instance.ActiveController.OperatorModel.pencil.Outcome - 1].power;

        Debug.Log(BattleManager.Instance.NonActiveController.OperatorModel.monsterBehaviour.MonsterModel.hp);
    }
}
