using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Battle {
	public class BattleManager : BaseSingletonMono<BattleManager> {

		public BattleContext playerContext = new BattleContext();
		public BattleContext enemyContext = new BattleContext();

		void Update() {
			// コンテキストのステート滞在中の処理
			playerContext.ExecuteUpdate();
			enemyContext.ExecuteUpdate();

			// 両コンテキストが待機中なら攻守交代
			if (playerContext.CurrentState == playerContext.stateIdle
				&& enemyContext.CurrentState == enemyContext.stateIdle) {
				playerContext.ChangeOffense();
				enemyContext.ChangeOffense();
			}
		}
	}
}