using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle {
	public class BattleContext {
		public readonly IBattleState stateInit = new BattleStateInit();
		public readonly IBattleState stateOffensiveDecision = new BattleStateOffensiveDecision();
		public readonly IBattleState stateIdle = new BattleStateIdle();
		public readonly IBattleState stateActionSelect = new BattleStateActionSelect();
		public readonly IBattleState stateDoAction = new BattleStateDoAction();
		
		public IBattleState CurrentState { get; private set; }

		public List<BattleContext> enemyContexts = new List<BattleContext>();
		public List<BattleContext> friendlyContexts = new List<BattleContext>();

		public bool isOffense = false;

		/// <summary>
		/// 生成時
		/// </summary>
		public BattleContext() {
			CurrentState = stateInit;
			CurrentState.ExecuteEntry(this);
		}

		/// <summary>
		/// 毎フレーム実行
		/// </summary>
		public void ExecuteUpdate() {
			CurrentState.ExecuteUpdate(this);
		}

		/// <summary>
		/// ステート遷移
		/// </summary>
		/// <param name="state">遷移先のステート</param>
		public void ChangeState(IBattleState state) {
			CurrentState.ExecuteExit(this);
			CurrentState = state;
			CurrentState.ExecuteEntry(this);
		}

		/// <summary>
		/// 攻守交替させる
		/// </summary>
		public void ChangeOffense() {
			isOffense = !isOffense;
		}
	}
}