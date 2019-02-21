using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilPosReset : MonoBehaviour {

	private void OnCollisionEnter(Collision collision) {
		Debug.Log(collision.gameObject.tag);

		if (collision.gameObject.tag == "Pencill") {
			if (collision.transform.parent.tag == "Player") {
				collision.transform.position = OperatorManager.Instance.PlayerController.OperatorModel.pencil.InitPencilPos;
			}
			else if (collision.transform.parent.tag == "CPU") {
				collision.transform.position = OperatorManager.Instance.ComputerController.OperatorModel.pencil.InitPencilPos;
			}
		}
	}
}
