using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySceneManager : BaseSingletonMono<MySceneManager> {

	[System.Serializable]
	public class ScenePrefabs {
		public List<GameObject> prefabs;
	}

	[Header("Prefab of Manager")]
	[SerializeField]
	List<ScenePrefabs> PrefabsEachScene = new List<ScenePrefabs>();
	
	List<GameObject> ActiveObjects = null;

	protected override void Awake() {
		base.Awake();

		PrefabsEachScene[0].prefabs.ForEach(prefab => Instantiate(prefab));
	}

	private void Start() {
	}

	private void Update() {
		// debug
		if (Input.GetKeyDown(KeyCode.B)) {
			Debug.Log("Space");
			StartCoroutine(TransNextScene(true));
		}
	}

	public IEnumerator TransNextScene(bool willDestroyActives) {
		if(willDestroyActives && ActiveObjects != null) {
			ActiveObjects.ForEach(manager => Destroy(manager));
			ActiveObjects.Clear();
		}
		yield return null;
	}
}
