using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : BaseSingletonMono<BattleManager> {

	BattleContext battleContext;
	public BattleContext BattleContext { get; private set; }

	public OperatorController PlayerController { get; set; }
	public OperatorController ComputerController { get; set; }

	protected override void Awake() {
		base.Awake();
		
		battleContext = new BattleContext();
	}

	void Update() {
		// コンテキストのステート滞在中の処理
		battleContext.ExecuteUpdate();
	}

	// 両者の投擲フェイズを開始
	public void StartOutcomeDetectionEachPencil() {
		PlayerController.OperatorModel.pencil.StartOutcomeDetection();
		ComputerController.OperatorModel.pencil.StartOutcomeDetection();
	}

	// 出目が異なる値かチェック
	public bool CheckOutcomesAreDifferent() {

		var playerOutcome = PlayerController.OperatorModel.pencil.Outcome;
		var cpuOutcome = ComputerController.OperatorModel.pencil.Outcome;

		if (playerOutcome == 0 || cpuOutcome == 0) return false;

		return  playerOutcome != cpuOutcome;
	}

	// 両者のモンスターを召喚
	public void SummonMonsters() {
		PlayerController.OperatorModel.pencil.SummonMonster();
		ComputerController.OperatorModel.pencil.SummonMonster();
	}
}
