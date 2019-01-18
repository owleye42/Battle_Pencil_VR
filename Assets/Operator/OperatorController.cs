using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorController : MonoBehaviour {

	[SerializeField]
	OperatorModel operatorModel;
	public OperatorModel OperatorModel { get { return operatorModel; } }

	[SerializeField]
	Transform monsterStandPos;

	readonly OperatorContext operatorContext = new OperatorContext();

	private void Start() {
		operatorModel.pencil = GetComponentInChildren<Pencil>();

		if(operatorModel.eOperator == OperatorModel.EOperator.Player)
			OperatorManager.Instance.PlayerController = this;
		else if(operatorModel.eOperator == OperatorModel.EOperator.Computer)
			OperatorManager.Instance.ComputerController = this;
	}

	void Update() {
		operatorContext.ExecuteUpdate();
	}
}
