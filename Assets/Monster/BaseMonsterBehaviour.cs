using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonsterBehaviour : MonoBehaviour
{

    [SerializeField]
    MonsterModel monsterModel;
    public MonsterModel MonsterModel { get { return monsterModel; } }
    public BaseMonsterBehaviour EnemyBehavior { get; private set; }

    MonsterContext monsterContext = null;

    // カウンター用
    public int enemyPower = 0;
    public bool isAttack = false;

    Transform standingTransform;
    public Animator MonsterAnimator { get; private set; }

    void Awake()
    {
        monsterContext = new MonsterContext();
        MonsterAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        if (gameObject.tag == "Player")
        {
            MonsterManager.Instance.PlayerMonsterBehaviour = this;
            EnemyBehavior = MonsterManager.Instance.ComputerMonsterBehaviour;
        }
        else if (gameObject.tag == "CPU")
        {
            MonsterManager.Instance.ComputerMonsterBehaviour = this;
            EnemyBehavior = MonsterManager.Instance.PlayerMonsterBehaviour;
        }

        GetComponentInParent<OperatorController>().OperatorModel.monsterBehaviour = this;
    }

    void FixedUpdate()
    {
        if (BattleManager.Instance.IsFight)
            monsterContext.ExecuteUpdate();
    }

    public IEnumerator GetJumpimgOnuma(Vector3 targetPosition)
    {
        StartCoroutine(JumpingOnuma(targetPosition));
        yield return null;
    }
    IEnumerator JumpingOnuma(Vector3 targetPos)
    {
        while (true)
        {
            //while(MonsterManager.Instance.PlayerMonsterBehaviour == null|| MonsterManager.Instance.ComputerMonsterBehaviour == null)
            //{
            //    yield return null;
            //}



            var distance = Vector3.Distance(this.transform.position, targetPos);
            while (distance >= 0.1f)
            {
                distance = Vector3.Distance(this.transform.position, targetPos);
                Debug.Log(distance);
                Vector3 targetDir = new Vector3(targetPos.x, transform.position.y, targetPos.z) - transform.position;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 100, 0f);
                transform.rotation = Quaternion.LookRotation(newDir);

                var rb = GetComponent<Rigidbody>();

                rb.AddForce(transform.forward * 2);
                yield return null;
            }

            if (distance < 0.1)
            {
                if (this.gameObject.tag == "Player")
                {

                     this.transform.rotation = Quaternion.LookRotation(OperatorManager.Instance.ComputerController.MonsterStandPos.position - transform.position);
                //    this.transform.rotation = Quaternion.LookRotation(GameObject.Find("ComputerMonsterPosition").transform.position - transform.position);
                }
                else if (this.gameObject.tag == "CPU")
                {

                     this.transform.rotation = Quaternion.LookRotation(OperatorManager.Instance.PlayerController.MonsterStandPos.position - transform.position);
                   // this.transform.rotation = Quaternion.LookRotation(GameObject.Find("PlayerMonsterPosition").transform.position - transform.position);

                }
            }


            break;
        }

    }
}
