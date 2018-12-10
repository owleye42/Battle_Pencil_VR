using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Battle {
	public class BattleManager : BaseSingletonMono<BattleManager> {

		public List<BattleContext> battleContexts = new List<BattleContext>();

		void Update() {
			// 各コンテキストの処理
			battleContexts.ForEach(context => {
				context.ExecuteUpdate();
			});

			// 全コンテキストが待機中なら攻守交代
			var allStatesAreIdle = battleContexts.All(context => context.CurrentState == context.stateIdle);
			if (allStatesAreIdle) {
				ChangeOffenseOfAllContexts();
			}
		}

		/// <summary>
		/// すべてのコンテキストを攻守交代させる
		/// </summary>
		void ChangeOffenseOfAllContexts() {
			battleContexts.ForEach(context => context.ChangeOffense());
		}
	}
}