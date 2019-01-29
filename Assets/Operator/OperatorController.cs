using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorController : MonoBehaviour {

	[SerializeField]
	OperatorModel operatorModel;
	public OperatorModel OperatorModel { get { return operatorModel; } }

	[SerializeField]
	Transform monsterStandPos;

	public readonly OperatorContext operatorContext = new OperatorContext();

	private void Start() {
		operatorModel.pencil = GetComponentInChildren<Pencil>();

		operatorContext.OperatorController = this;

		if (operatorModel.eOperator == OperatorModel.EOperator.Player)
			OperatorManager.Instance.PlayerController = this;
		else if (operatorModel.eOperator == OperatorModel.EOperator.Computer)
			OperatorManager.Instance.ComputerController = this;

		BattleManager.Instance.ControllerList.Add(this);
	}

	void Update() {
		operatorContext.ExecuteUpdate();
	}

	public void ForceThrowPencil() {
		GetComponent<Throw_ball>().ThrowPencil();
	}

	public void StartThrow() {
		operatorContext.ChangeState(operatorContext.stateThrow);
	}

	public void StopThrow() {
		operatorContext.ChangeState(operatorContext.stateWait);
	}
}
