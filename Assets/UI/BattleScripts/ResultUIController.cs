using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUIController : MonoBehaviour {

	[SerializeField]
	string playerWinsText;

	[SerializeField]
	string playerLosesText;

	void Start() {
		if (OperatorManager.Instance.PlayerController.OperatorModel.monsterBehaviour.MonsterModel.hp > 0)
			GetComponent<Text>().text = playerWinsText;
		else
			GetComponent<Text>().text = playerLosesText;
	}
}
