using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencil : MonoBehaviour {

	// 初期位置
	public Vector3 InitPencilPos { get; set; }

	// 仮の出目
	public int TmpOutcome { get; private set; }
	// 出目
	public int Outcome { get; private set; }

	// 召喚し終わったか
	public bool IsSummoned { get; private set; }

	// 召喚するモンスターのプレハブ
	[SerializeField]
	GameObject monsterPrefab;

	void Init() {
		Outcome = 0;
		TmpOutcome = 0;
		IsSummoned = false;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

	private void Awake() {
		Init();
		InitPencilPos = transform.position;
	}

	private void Start() {
	}

	public void StartOutcomeDetection() {
		Init();
		StartCoroutine(OutcomeDetectionCoroutine());
	}

	// 鉛筆投擲フェイズのコルーチン
	IEnumerator OutcomeDetectionCoroutine() {

		var rigidbody = GetComponent<Rigidbody>();

		// 静止時間
		float restTime = 0;

		while (true) {
			// 出目表示用の出目変数に格納
			TmpOutcome = LuckDetermination();

			// 静止していたら
			if (rigidbody.velocity.sqrMagnitude == 0) {
				restTime += Time.deltaTime;
			}

			// 静止時間が一定値を超えたら
			if (restTime > 0.1) {

				// 出目が確定するまで出目判定を行う
				while (Outcome == 0) {

					Debug.Log(gameObject.name + Outcome);
					Outcome = LuckDetermination();
					yield return null;
				}
				
				break;
			}


		   yield return null;
		}
	}

	Ray ray;

	//出目判定
	public int LuckDetermination() {
		int num = 0;

		ray = new Ray(transform.position + new Vector3(0, 0.5f, 0), Vector3.down);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 10)) {
			if (hit.collider.tag == "numbers") {
				num = hit.collider.gameObject.GetComponent<number>().num;

				Debug.Log(gameObject.name + "出目" + num);
			}
		}
		return num;
	}

	// Rayの描画
	private void OnDrawGizmos() {
		Debug.DrawRay(ray.origin, new Vector3(0, -1, 0), Color.gray);
		Gizmos.DrawRay(ray);
	}

	// モンスターの召喚
	public void SummonMonster() {
		// 召喚されていないなら
		if (IsSummoned == false) {
			Debug.Log("summon!");
			var monsterObj = Instantiate(monsterPrefab, transform.position, Quaternion.identity);

			IsSummoned = true;
		}
	}
}
