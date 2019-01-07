using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : BaseSingletonMono<BattleManager> {

	BattleContext battleContext;
	public BattleContext BattleContext { get; private set; }

	public BaseMonsterBehaviour playerMonsterBehaviour = null;
	public BaseMonsterBehaviour computerMonsterBehaviour = null;

	public MonsterContext playerMonsterContext = null;
	public MonsterContext computerMonsterContext = null;

	public Pencil playerPencil = null;
	public Pencil computerPencil = null;

	public Transform playerMonsterStandingTransform;
	public Transform computerMonsterStandingTransform;

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

	public void StartThrowPhasePencils() {
		playerPencil.StartThrowPhase();
		computerPencil.StartThrowPhase();
	}

	public bool CheckPencilsAreEnd() {
		return playerPencil.IsEnd && computerPencil.IsEnd;
	}

	public bool CheckOutcomesDifference() {
		return playerPencil.Outcome == computerPencil.Outcome;
	}
}
