using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonsterBehaviour : MonoBehaviour {

	[SerializeField]
	BaseMonsterBehaviour opponentBehaviour;

	BattleContext context = new BattleContext();
	BattleContext Context { get { return context; } }

	void Start() {
		BattleManager.Instance.battleContexts.Add(context);
		context.opponentContext = opponentBehaviour.Context;

		//Debug.Log(context.GetHashCode() + "..." + opponentBehaviour.Context.GetHashCode());
	}

	void Update() {

	}
}
