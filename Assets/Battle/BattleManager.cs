using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : BaseSingletonMono<BattleManager> {

	BattleContext battleContext;
	public BattleContext BattleContext { get; private set; }

	public OperatorController PlayerController { get; set; }
	public OperatorController ComputerController { get; set; }

	public bool IsThrowable { get; set; }

	protected override void Awake() {
		base.Awake();

		IsThrowable = false;
		battleContext = new BattleContext();
	}

	void Update() {
		// コンテキストのステート滞在中の処理
		battleContext.ExecuteUpdate();
	}

	// 
	public void StartThrowPhaseEachPencil() {
		PlayerController.OperatorModel.pencil.StartThrowPhase();
		ComputerController.OperatorModel.pencil.StartThrowPhase();
	}

	public bool CheckOutcomesAreDifferent() {
		return PlayerController.OperatorModel.pencil.Outcome 
			!= ComputerController.OperatorModel.pencil.Outcome;
	}

	public void SummonMonsters() {
		PlayerController.OperatorModel.pencil.SummonMonster();
		ComputerController.OperatorModel.pencil.SummonMonster();
		
	}
}
