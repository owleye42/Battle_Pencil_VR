using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : BaseSingletonMono<DataManager> {

	public GameObject PrefabPlayerPencil { get; private set; }
	public GameObject PrefabComputerPencil { get; private set; }

	public bool isPlayerWinner = false;

	[SerializeField]
	List<GameObject> prefPencils = new List<GameObject>();

	public void SetPlayerPencil(int id) {
		PrefabPlayerPencil = prefPencils[id];
	}

	public void SetComputerPencilRandom() {
		PrefabComputerPencil = prefPencils[Random.Range(0, prefPencils.Count)];
	}
}
