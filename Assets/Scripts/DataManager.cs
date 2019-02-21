using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : BaseSingletonMono<DataManager> {
	public Canvas titleCanvas;
	public Canvas gameCanvas;

	public Transform canvasPos;

	public Transform cameraPosition;
	public Transform playPosition;

	public GameObject prefabPlayerPencil;
	public GameObject prefabComputerPencil;

	public List<GameObject> prefPencils = new List<GameObject>();

	protected override void Awake() {
		base.Awake();

		prefabComputerPencil = prefPencils[Random.Range(0, prefPencils.Count)];
	}

	private void Update() {
		//仮処理
		if (Input.GetKeyDown(KeyCode.A)) {
			StartCoroutine(ChengeCanvas());
		}
	}

	public IEnumerator ChengeCanvas() {
		Destroy(titleCanvas.gameObject);
		var canvas = Instantiate(gameCanvas);
		canvas.transform.position = canvasPos.position;
		yield return null;
	}

	public void SetPlayerPencil(int id) {
		prefabPlayerPencil = prefPencils[id];
	}
}
