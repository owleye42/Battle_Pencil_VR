using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySceneManager : BaseSingletonMono<MySceneManager> {

	[Header("Prefab of Manager")]
	[SerializeField]
	List<GameObject> TitleScenePrefabs = new List<GameObject>();

	[SerializeField]
	List<GameObject> SelectScenePrefabs = new List<GameObject>();

	[SerializeField]
	List<GameObject> GameScenePrefabs = new List<GameObject>();

	int sceneNum = 0;

	List<List<GameObject>> PrefabListEachScene = new List<List<GameObject>>();

	List<GameObject> ActiveObjects = null;

	protected override void Awake() {
		base.Awake();

		PrefabListEachScene.Add(TitleScenePrefabs);
		PrefabListEachScene.Add(SelectScenePrefabs);
		PrefabListEachScene.Add(GameScenePrefabs);

		ActiveObjects = PrefabListEachScene[0];
	}

	private void Start() {
		DataManager.Instance.SetPlayerPencil(0);
	}

	private void Update() {
		// debug
		if (Input.GetKeyDown(KeyCode.Space)) {
			StartCoroutine(TransNextScene());
		}
	}

	public IEnumerator TransNextScene() {
		if(ActiveObjects != null) {
			ActiveObjects.ForEach(manager => Destroy(manager));
			ActiveObjects.Clear();
		}

		sceneNum++;

		foreach(var manager in PrefabListEachScene[sceneNum % PrefabListEachScene.Count]) {
			ActiveObjects.Add(Instantiate(manager));
			yield return new WaitForEndOfFrame();
		}
	}
}
