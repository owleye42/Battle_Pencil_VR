using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : BaseSingletonMono<BattleManager> {

	BattleContext battleContext;
	public BattleContext BattleContext { get; private set; }

	public BaseMonsterBehaviour playerMonsterBehaviour;
	public BaseMonsterBehaviour computerMonsterBehaviour;

	public Transform playerStandingTransform;
	public Transform computerStandingTransform;

	public int outcome = 0;
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
}
