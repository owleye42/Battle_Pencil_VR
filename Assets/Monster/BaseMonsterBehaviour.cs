using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonsterBehaviour : MonoBehaviour
{

    [SerializeField]
    MonsterModel monsterModel;
    public MonsterModel MonsterModel { get { return monsterModel; } }
    public MonsterContext MonsterContext { private set; get; }

    Transform standingTransform;
    public Animator _animator { get; private set; }
    
    void Awake()
    {
        MonsterContext = new MonsterContext();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        GetComponentInParent<OperatorController>().OperatorModel.monsterBehaviour = this;
    }

    void FixedUpdate()
    {

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
                //Debug.Log(distance);
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
