using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle {
	public class BaseMonsterBehaviour : MonoBehaviour {

		[SerializeField]
		BaseMonsterBehaviour enemyBehaviour;

		MonsterModel monsterModel;

		public BattleContext Context { get; private set; }

		void Awake() {
			Context = new BattleContext();
		}

		void Start() {
			BattleManager.Instance.battleContexts.Add(Context);
			Context.enemyContexts.Add(enemyBehaviour.Context);

			//Debug.Log(context.GetHashCode() + "..." + opponentBehaviour.Context.GetHashCode());
		}

		void Update() {

		}
	}
}