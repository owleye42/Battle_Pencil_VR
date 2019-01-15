using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencil : MonoBehaviour {

	// 出目
	public int Outcome { get; private set; }

	// 静止時間
	float stopTime = 0;

	// 召喚し終わったか
	bool isEnd = false;
	public bool IsEnd { get { return isEnd; } }

	// プレイヤーの鉛筆か
	public bool isPlayer = false;

	// 召喚するモンスターのプレハブ
	[SerializeField]
	GameObject monsterPrefab;
	GameObject monsterInstance = null;

	void Init() {
		Outcome = 0;
		stopTime = 0;
		isEnd = false;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

	private void Awake() {
		Init();
	}

	private void Start() {
		if (isPlayer)
			BattleManager.Instance.playerPencil = this;
		else
			BattleManager.Instance.computerPencil = this;
	}

	public void StartThrowPhase() {
		Init();
		StartCoroutine(ThrowPhaseCoroutine());
	}

	// 鉛筆投擲フェイズのコルーチン
	public IEnumerator ThrowPhaseCoroutine() {

		var rigidbody = GetComponent<Rigidbody>();
		
		while (true) {

			// 投擲フェイズが終わっていないなら
			if (!isEnd) {
         //       Debug.Log(rigidbody.velocity.magnitude+"magnitude");
				// 静止していたら
				if (rigidbody.velocity.sqrMagnitude == 0)
					stopTime += Time.deltaTime;

				// 静止時間が一定値を超えたら
				if (stopTime > 0.1) {
					yield return StartCoroutine(LuckDetectCoroutine());
					yield return StartCoroutine(SummonMonster());
					isEnd = true;
				}
			}

			yield return null;
		}
	}

	// 出目判定のコルーチン
	IEnumerator LuckDetectCoroutine() {
		while (true) {
            Debug.Log(isPlayer+""+Outcome);
			// 出目判定を格納
			Outcome = LuckDetermination();

			// 出目が1~6の範囲内なら
			if (Outcome >= 1 && Outcome <= 6) {
                Debug.Log(Outcome);
				break;
			}
			yield return null;
		}
		
		yield return null;
	}

	// モンスターの召喚
	IEnumerator SummonMonster() {
		if (monsterInstance == null) {
			monsterInstance = Instantiate(monsterPrefab, transform.position, Quaternion.identity);
			monsterInstance.GetComponent<BaseMonsterBehaviour>().isPlayer = isPlayer;
            StartCoroutine(monsterInstance.GetComponent<BaseMonsterBehaviour>().GetJumpimgOnuma(monsterInstance,GameObject.Find("CpuMonsterPoint").transform.position,45f));
            Debug.Log(isPlayer+"召喚");
        }
    
		yield return null;
	}

	Ray ray;

	//出目判定
	public int LuckDetermination() {
		int num = 0;

		//鉛筆の上からRayを出して判定

		ray = new Ray(transform.position + new Vector3(0, 1, 0), Vector3.down+Vector3.down);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 1)) {
			if (hit.collider.tag == "numbers") {
				num = hit.collider.gameObject.GetComponent<number>().num;
			//	Debug.Log("出目" + num);
				return num;
			}
		}
		return num;
	}

	private void OnDrawGizmos() {
		Ray ray = new Ray(transform.position + new Vector3(0, 10, 0), new Vector3(0, -10, 0));
		Debug.DrawRay(ray.origin, new Vector3(0, -1, 0), Color.gray);
		Gizmos.DrawRay(ray);
	}

	private void OnCollisionStay(Collision collision) {
		if (isPlayer && collision.gameObject.tag == "PlayerTable") {
			TableManager.instance.playerTabel.OfEneyTurnCol();
			TableManager.instance.playerTabel.AllEnable();
		}
		else if (!isPlayer && collision.gameObject.tag == "CPUTable") {
			TableManager.instance.cpuTable.OfEneyTurnCol();
			TableManager.instance.cpuTable.AllEnable();
		}
	}
}
