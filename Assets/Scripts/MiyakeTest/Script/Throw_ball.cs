using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_ball : MonoBehaviour {
    [Header("鉛筆のプレハブ")]
    [SerializeField] GameObject penPref;
    [Header("投射時の目標地点")]
    [SerializeField] GameObject targetObj;
    [Header("投射角度")]
    [SerializeField, Range(-30, 30)] float tAngle;
    [Header("投射の強さ")]
    [SerializeField, Range(0, 20)] float tRange;
	[SerializeField] Judgment judgment;

	[SerializeField] GameObject pen = null;

	private void Update() {
		//Debug.Log(targetObj.transform.position);
	}

	public void ThrowPencil() {
		pen.transform.position = transform.position;

		// 標的の座標
		Vector3 targetPosition = targetObj.transform.position;
		// 射出角度
		float angle = tAngle + Random.Range(-tRange/2, tRange / 2);
		// 射出速度を算出
		Vector3 velocity = CalculateVelocity(this.transform.position, targetPosition, angle);
		// 射出
		Rigidbody rigidbody = pen.GetComponent<Rigidbody>();
		rigidbody.velocity = Vector3.zero;
		rigidbody.AddForce(velocity * rigidbody.mass, ForceMode.Impulse);
	}

	private Vector3 CalculateVelocity(Vector3 pointA, Vector3 pointB, float angle) {
		// 射出角をラジアンに変換
		float rad = angle * Mathf.PI / 180;

		// 水平方向の距離x
		float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));

		// 垂直方向の距離y
		float y = pointA.y - pointB.y;

		// 斜方投射の公式を初速度について解く
		float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

		if (float.IsNaN(speed)) {
			// 条件を満たす初速を算出できなければVector3.zeroを返す
			return Vector3.zero;
		}
		else {
			return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
		}
	}

}
