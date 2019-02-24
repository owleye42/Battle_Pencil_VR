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

	[SerializeField]
	Transform pencilSpawnPos;

	public OperatorContext OperatorContext { get; private set; }

	public int timeLimit;

	private void Start() {
		OperatorContext = new OperatorContext(timeLimit) {
			OperatorController = this
		};

		var pencilPrefab = DataManager.Instance.PrefabPlayerPencil;

		if (operatorModel.eOperator == OperatorModel.EOperator.Player) {
			OperatorManager.Instance.PlayerController = this;
			pencilPrefab = DataManager.Instance.PrefabPlayerPencil;
		}
		else if (operatorModel.eOperator == OperatorModel.EOperator.Computer) {
			OperatorManager.Instance.ComputerController = this;
			pencilPrefab = DataManager.Instance.PrefabComputerPencil;
		}

		var pen = Instantiate(pencilPrefab, pencilSpawnPos.position, Quaternion.identity, pencilSpawnPos);
		operatorModel.pencil = pen.GetComponent<Pencil>();

		BattleManager.Instance.ControllerList.Add(this);
	}

	void Update() {
		OperatorContext.ExecuteUpdate();
	}

	public void ForceThrowPencil() {
		GetComponentInChildren<Throw_ball>().ThrowPencil();
	}

	public void StartThrow() {
		OperatorContext.ChangeState(OperatorContext.stateThrow);
		operatorModel.pencil.StartOutcomeDetection();
	}

	public void StopThrow() {
		OperatorContext.ChangeState(OperatorContext.stateWait);
	}
}
