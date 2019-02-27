using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGlass : MonoBehaviour {

	[SerializeField]
	int id = 0;

    [SerializeField]
    bool onHand = false;

    [SerializeField]
    GameObject defaultPos;

    private Transform followTfm;
    float smoothTime = 0.2f;
    Vector3 velocity = Vector3.zero;
    Rigidbody rigidbody;
<<<<<<< HEAD
    [Header("中のモンスターオブジェクト")]
    [SerializeField] GameObject monsterObj;

    [SerializeField] GameObject headpos;

    [SerializeField] AudioClip selectClip;
   
=======
>>>>>>> 029b1648cbe1a127e5d60200943668984572935f

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Head")
        {
			DataManager.Instance.SetPlayerPencil(id);
<<<<<<< HEAD
            Debug.Log(monsterObj.name);
            SoundManager.Instance.PlayeSE(selectClip.name);

=======

			Fade_In_Out.Instance.StartFade(1, 3, 1, () => {
				BlackBoardManager.Instance.ChangeCanvas(BlackBoardManager.ECanvasType.Battle);
				MySceneManager.Instance.ChangeScene(MySceneManager.ESceneType.Battle);
				PositionManager.Instance.ChangePosition(0, 1);
			});
>>>>>>> 029b1648cbe1a127e5d60200943668984572935f
        }
        if (other.gameObject.tag == "Controller")
        {
            onHand = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Controller")
        {
            onHand =false;
            rigidbody.velocity = Vector3.zero;
        }
    }

    private void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        followTfm = defaultPos.transform;
    }

    private void Update()
    {
        
        //float angle = Mathf.LerpAngle(0, 0, Time.time);
        //transform.eulerAngles = new Vector3(0, angle, 0);
        if (!onHand)
        {
            Vector3 targetPos = followTfm.TransformPoint(new Vector3(0f, 0f, 0f));

            // 移動
            transform.position =
                Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
            //元の位置に戻る処理
           
        }

    }
}
