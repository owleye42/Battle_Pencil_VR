using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BattleManager : BaseSingletonMono<BattleManager> {

	BattleContext battleContext;
	public BattleContext BattleContext { get; private set; }

	protected override void Awake() {
		base.Awake();

		battleContext = new BattleContext();
	}

	void Update() {
		// コンテキストのステート滞在中の処理
		battleContext.ExecuteUpdate();
	}
}
