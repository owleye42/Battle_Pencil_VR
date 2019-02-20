using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesController : BaseSingletonMono<ScenesController> {

	[SerializeField]
	List<GameObject> TitleSceneManagers = new List<GameObject>();

	[SerializeField]
	List<GameObject> SelectSceneManagers = new List<GameObject>();

	[SerializeField]
	List<GameObject> GameSceneManagers = new List<GameObject>();

	List<GameObject> ActiveSceneManagers = null;

	private void Awake() {
		
	}
}
