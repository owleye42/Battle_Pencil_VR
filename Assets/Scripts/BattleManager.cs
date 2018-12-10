using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : BaseSingletonMono<BattleManager> {

	public delegate void MouseClickHandler();
	public event MouseClickHandler OnClick;

	public List<BattleContext> battleContexts = new List<BattleContext>();

	void Update() {
		var allContextIsReady = false;
		battleContexts.ForEach(context => {
			context.ExecuteUpdate();
		});
	}

	void ChangeDeffensive() {

	}
}
