using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorController : MonoBehaviour {

	[SerializeField]
	OperatorModel operatorModel;
	public OperatorModel OperatorModel { get { return operatorModel; } }

	[SerializeField]
	Transform monsterStandPos;
    public Transform MonsterStandPos { get { return monsterStandPos; } }

	public OperatorContext OperatorContext { get; private set; }

	public int timeLimit;

	private void Start() {
		OperatorContext = new OperatorContext(timeLimit) {
			OperatorController = this
		};

		if (operatorModel.eOperator == OperatorModel.EOperator.Player) {
			OperatorManager.Instance.PlayerController = this;
		}
		else if (operatorModel.eOperator == OperatorModel.EOperator.Computer) {
			OperatorManager.Instance.ComputerController = this;
		}

		BattleManager.Instance.ControllerList.Add(this);
	}

	void Update() {
		OperatorContext.ExecuteUpdate();
	}

	public void ForceThrowPencil() {
		GetComponent<Throw_ball>().ThrowPencil();
	}

	public void StartThrow() {
		OperatorContext.ChangeState(OperatorContext.stateThrow);
	}

	public void StopThrow() {
		OperatorContext.ChangeState(OperatorContext.stateWait);
	}
}
