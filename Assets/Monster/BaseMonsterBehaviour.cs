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
        if (this.gameObject.tag == "Player")
        {
            MonsterManager.Instance.PlayerMonsterBehaviour=this;
        }else if (this.gameObject.tag == "CPU")
        {
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

    public IEnumerator GetJumpimgOnuma(Vector3 targetPos)
    {
        StartCoroutine(JumpingOnuma( targetPos));
        yield return null;
    }

    IEnumerator JumpingOnuma(Vector3 targetPos)
    {
        while (true)
        {
            var distance= Vector3.Distance(this.transform.position,targetPos);
            while (distance > 0.15f)
            {
                distance = Vector3.Distance(this.transform.position, targetPos);

                Vector3 targetDir = new Vector3(targetPos.x, transform.position.y, targetPos.z) - transform.position;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 100, 0f);
                transform.rotation = Quaternion.LookRotation(newDir);

                var rb = GetComponent<Rigidbody>();

                rb.AddForce(transform.forward);
                yield return null;
            }

            if (distance < 0.15)
            {
                if (this.gameObject.tag == "Player")
            { 
                    this.transform.rotation = Quaternion.LookRotation(MonsterManager.Instance.ComputerMonsterBehaviour.gameObject.transform.position - transform.position);
            }
            else if (this.gameObject.tag == "CPU")
            {
                this.transform.rotation = Quaternion.LookRotation(MonsterManager.Instance.PlayerMonsterBehaviour.gameObject.transform.position - transform.position);
            }
            }


            break;
        }
    }

    
}
