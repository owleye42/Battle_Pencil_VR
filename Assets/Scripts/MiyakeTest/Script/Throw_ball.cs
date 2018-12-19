using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_ball : MonoBehaviour {

    [SerializeField] GameObject penPref;
    [SerializeField] GameObject targetObj;
    [SerializeField] float tAngle;
    [SerializeField] Judgment judgment;

	GameObject pen = null;

    private void Update()
    {
        //Debug.Log(targetObj.transform.position);
    }
    public void CreatePencil()
    {
        if (BattleManager.Instance.IsThrowable && penPref != null && targetObj != null)
        {
			if (pen != null) {
				TableManager.instance.cpuTable .AllDisable();

                TableManager.instance.playerTabel.AllDisable();
                pen.transform.position = transform.position;
			}
			else {
				// Ballオブジェクトの生成
				pen = Instantiate(penPref, this.transform.position, transform.rotation);
			}

			judgment.target = pen;
            // 標的の座標
            Vector3 targetPosition = targetObj.transform.position;
            // 射出角度
            float angle = tAngle;//Random.Range(41,49) ;
            // 射出速度を算出
            Vector3 velocity = CalculateVelocity(this.transform.position, targetPosition, angle);
            // 射出
            Rigidbody rigidbody = pen.GetComponent<Rigidbody>();
            rigidbody.AddForce(velocity * rigidbody.mass, ForceMode.Impulse);
        }
        
    }



    private Vector3 CalculateVelocity(Vector3 pointA, Vector3 pointB, float angle)
    {
        // 射出角をラジアンに変換
        float rad = angle * Mathf.PI / 180;

        // 水平方向の距離x
        float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));

        // 垂直方向の距離y
        float y = pointA.y - pointB.y;

        // 斜方投射の公式を初速度について解く
        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        if (float.IsNaN(speed))
        {
            // 条件を満たす初速を算出できなければVector3.zeroを返す
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
        }
    }

}
