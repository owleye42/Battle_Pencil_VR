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
		if (DataManager.Instance.isPlayerWinner)
			GetComponent<Text>().text = playerWinsText;
		else
			GetComponent<Text>().text = playerLosesText;
	}
}
