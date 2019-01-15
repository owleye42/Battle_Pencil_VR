using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonsterBehaviour : MonoBehaviour {

	[SerializeField]
	MonsterModel monsterModel;
	public MonsterModel MonsterModel { get { return monsterModel; } }

	public BaseMonsterBehaviour EnemyBehavior;

	public bool isPlayer = false;

	MonsterContext monsterContext = null;

    public bool isCounter = false;

    Transform standingTransform;

	void Awake() {
		monsterContext = new MonsterContext();
	}

	void Start() {
		GetComponentInParent<OperatorController>().OperatorModel.monsterBehaviour = this;

		if(gameObject.tag == "Player") {
			MonsterManager.Instance.PlayerMonsterBehaviour = this;
		}
		else if(gameObject.tag == "Computer") {
			MonsterManager.Instance.ComputerMonsterBehaviour = this;
		}
	}

	void Update() {

	}

	public void ActionSelect(int skill_id) {
        isCounter = false;

		if (monsterModel.skillList[skill_id].skillType == SkillType.Attack) {
            if(EnemyBehavior.isCounter){
                monsterModel.hp -= EnemyBehavior.monsterModel.skillList[skill_id].power * 2;
                Debug.Log(monsterModel.hp);
            }
            else{
			    EnemyBehavior.monsterModel.hp -= monsterModel.skillList[skill_id].power;
			    Debug.Log(EnemyBehavior.monsterModel.hp);
            }
		}
        else if(monsterModel.skillList[skill_id].skillType == SkillType.Heal) {
			monsterModel.hp += monsterModel.skillList[skill_id].power;
			Debug.Log(monsterModel.hp);
		}
        else if(monsterModel.skillList[skill_id].skillType == SkillType.Counter){
            isCounter = true;
        }
		else if (monsterModel.skillList[skill_id].skillType == SkillType.Miss) {
			Debug.Log("MISS!!!!!!!!!!!!!!!!");
		}
	}

    public IEnumerator GetJumpimgOnuma(GameObject jumpObj, Vector3 targetPosition, float tAngle)
    {
        StartCoroutine(JumpingOnuma( jumpObj,  targetPosition, tAngle));
        yield return null;
    }

    IEnumerator JumpingOnuma(GameObject jumpObj,Vector3 targetPosition,float tAngle)
    {
        Debug.Log("超エキサイティング！");
        	// 標的の座標
        // 射出角度
        float angle = tAngle;
        Vector3 velocity = CalculateVelocity(jumpObj.transform.position, targetPosition, angle);

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(velocity * rigidbody.mass, ForceMode.Impulse);

        yield return null;
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
