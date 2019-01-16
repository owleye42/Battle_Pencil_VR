using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : BaseSingletonMono<BattleManager> {
	
	public BattleContext BattleContext { get; private set; }

	protected override void Awake() {
		base.Awake();
		
		BattleContext = new BattleContext();
	}

	void Update() {
		// コンテキストのステート滞在中の処理
		BattleContext.ExecuteUpdate();
	}

	// 両者の投擲フェイズを開始
	public void StartOutcomeDetectionEachPencil() {
		OperatorManager.Instance.PlayerController.OperatorModel.pencil.StartOutcomeDetection();
		OperatorManager.Instance.ComputerController.OperatorModel.pencil.StartOutcomeDetection();
	}

	// 出目が異なる値かチェック
	public bool CheckOutcomesAreDifferent() {

		var playerOutcome = OperatorManager.Instance.PlayerController.OperatorModel.pencil.Outcome;
		var cpuOutcome = OperatorManager.Instance.ComputerController.OperatorModel.pencil.Outcome;

		if (playerOutcome == 0 || cpuOutcome == 0) return false;

		return  playerOutcome != cpuOutcome;
	}

	// 両者のモンスターを召喚
	public void SummonMonsters() {
		OperatorManager.Instance.PlayerController.OperatorModel.pencil.SummonMonster();
		OperatorManager.Instance.ComputerController.OperatorModel.pencil.SummonMonster();
	}
}
