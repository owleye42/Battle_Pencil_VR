using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencil : MonoBehaviour {

	float stopTime = 0;
	bool isEnd = false;

	public bool isPlayer = false;

	[SerializeField]
	GameObject monsterPrefab;
	GameObject monsterInstance = null;

	Transform standingTransform;

	private void Awake() {
		Init();
	}

	private void Start() {
	}

	void Init() {
		stopTime = 0;
		isEnd = false;
	}

	private void Update() {
		if (!isEnd) {
			if (GetComponent<Rigidbody>().velocity.sqrMagnitude == 0)
				stopTime += Time.deltaTime;

			if (stopTime > 0.1) {
				StartCoroutine(LuckDetectCoroutine());
				isEnd = true;
			}
		}
	}

	IEnumerator LuckDetectCoroutine() {
		while (true) {
			int num = Judgment.instance.LuckDetermination();

			if (num >= 1 && num <= 6) {
				BattleManager.Instance.outcome = num;
				break;
			}
			yield return null;
		}
		yield return SummonMonster();
	}

	IEnumerator SummonMonster() {
		if (monsterInstance == null)
			monsterInstance = Instantiate(monsterPrefab, transform.position, Quaternion.identity);

		yield return null;
	}
}
