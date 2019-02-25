using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySceneManager : BaseSingletonMono<MySceneManager> {

	public enum ESceneType {
		Title, Battle
	}

	[System.Serializable]
	public class ScenePrefabs {
		public ESceneType type;
		public List<GameObject> prefabs;
	}

	[SerializeField]
	List<ScenePrefabs> prefabsEachScene = new List<ScenePrefabs>();

	List<GameObject> activeObjects = new List<GameObject>();

	protected override void Awake() {
		base.Awake();
	}

	private void Start() {
	}

	public void ChangeScene(ESceneType type) {
		if (activeObjects != null) {
			activeObjects.ForEach(obj => Destroy(obj));
			activeObjects.Clear();
		}

		StartCoroutine(CreateObjects(type));
	}

	IEnumerator CreateObjects(ESceneType type) {
		foreach(var sp in prefabsEachScene) {
			if (type == sp.type) {
				foreach(var prefab in sp.prefabs) {
					var obj = Instantiate(prefab);
					activeObjects.Add(obj);
					yield return new WaitForEndOfFrame();
				}
			}
		}
	}
}
