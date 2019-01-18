using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorController : MonoBehaviour {

	[SerializeField]
	OperatorModel operatorModel;
	public OperatorModel OperatorModel { get { return operatorModel; } }

	readonly OperatorContext operatorContext = new OperatorContext();

	[SerializeField]
	Transform monsterStandPos;
    public Transform MonsterStandPos { get { return monsterStandPos; } }

    private void Start() {
		operatorModel.pencil = GetComponentInChildren<Pencil>();

		if(operatorModel.eOperator == OperatorModel.EOperator.Player)
			BattleManager.Instance.PlayerController = this;
		else if(operatorModel.eOperator == OperatorModel.EOperator.Computer)
			BattleManager.Instance.ComputerController = this;
	}

	void Update() {
		operatorContext.ExecuteUpdate();
	}
}
