using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : BaseSingletonMono<BattleManager> {

	[System.NonSerialized]
	public List<OperatorController> ControllerList = new List<OperatorController>();
	public OperatorController ActiveController { get; set; }

	public BattleContext BattleContext { get; private set; }

	protected override void Awake() {
		base.Awake();
		
		BattleContext = new BattleContext();
		ActiveController = null;
	}

	void Update() {
		// コンテキストのステート滞在中の処理
		BattleContext.ExecuteUpdate();
	}

	// 投擲フェイズ開始
	// アクティブなコントローラだけ
	public void StartOutcomeDetection() {
		var nonActiveList = new List<bool>();

		ControllerList.ForEach(oc => nonActiveList.Add(oc != ActiveController));

		if (nonActiveList.Contains(false))
			ActiveController.OperatorModel.pencil.StartOutcomeDetection();
		else {
			ControllerList.ForEach(oc => {
				oc.StartThrow();
				oc.OperatorModel.pencil.StartOutcomeDetection();
			});
		}
		Debug.Log("startOutcomeDetection");
	}

	// どちらかの出目が0かチェック
	public bool CheckOutcomesContainZero() {
		var playerOutcome = OperatorManager.Instance.PlayerController.OperatorModel.pencil.Outcome;
		var cpuOutcome = OperatorManager.Instance.ComputerController.OperatorModel.pencil.Outcome;
		
		return playerOutcome == 0 || cpuOutcome == 0;
	}

	// 出目が同値かチェック
	public bool CheckEachOutcomeSame() {
		var playerOutcome = OperatorManager.Instance.PlayerController.OperatorModel.pencil.Outcome;
		var cpuOutcome = OperatorManager.Instance.ComputerController.OperatorModel.pencil.Outcome;

		return playerOutcome == cpuOutcome;
	}

	// 出目が異なる値かチェック
	public bool CheckEachOutcomeDifferent() {

		var playerOutcome = OperatorManager.Instance.PlayerController.OperatorModel.pencil.Outcome;
		var cpuOutcome = OperatorManager.Instance.ComputerController.OperatorModel.pencil.Outcome;

		return  playerOutcome != cpuOutcome;
	}

	public void SwitchAvtiveController() {
		if (ActiveController == ControllerList[0])
			ActiveController = ControllerList[1];
		else if(ActiveController == ControllerList[1])
			ActiveController = ControllerList[0];
	}

	public void ChangeStateActiveController(IState<OperatorContext> state) {
		ActiveController.operatorContext.ChangeState(state);
	}

	public void FinishFightState() {
		BattleContext.isDone = true;
	}

	public void FinishGame() {
		foreach(var oc in ControllerList) {
			oc.operatorContext.ToResult();
		}
		BattleContext.ToResult();
	}

	public void StartThrowActiveController() {
		ActiveController.operatorContext.ChangeState(ActiveController.operatorContext.stateThrow);
	}

	public void StartWaitActiveController() {
		ActiveController.operatorContext.ChangeState(ActiveController.operatorContext.stateWait);
	}
}
