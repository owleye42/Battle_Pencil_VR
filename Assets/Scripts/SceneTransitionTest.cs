using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class SceneTransitionTest : MonoBehaviour {

	[SerializeField]
	Button title;

	[SerializeField]
	Button select;

	[SerializeField]
	Button battle;

	[SerializeField]
	Button result;

	void Start () {
		title.gameObject.SetActive(false);
		battle.gameObject.SetActive(false);
		result.gameObject.SetActive(false);

		BlackBoardManager.Instance.ChangeCanvas(BlackBoardManager.ECanvasType.Title);
		select.gameObject.SetActive(true);
		MySceneManager.Instance.ChangeScene(MySceneManager.ESceneType.Title);
		PositionManager.Instance.ChangePosition(0, 0);

		title.OnClickAsObservable().Subscribe(_ => {
			BlackBoardManager.Instance.ChangeCanvas(BlackBoardManager.ECanvasType.Title);
			select.gameObject.SetActive(true);
			MySceneManager.Instance.ChangeScene(MySceneManager.ESceneType.Title);
			title.gameObject.SetActive(false);
			PositionManager.Instance.ChangePosition(0, 0);
		});

		select.OnClickAsObservable().Subscribe(_ => {
			BlackBoardManager.Instance.ChangeCanvas(BlackBoardManager.ECanvasType.Select);
			battle.gameObject.SetActive(true);
			select.gameObject.SetActive(false);
		});

		battle.OnClickAsObservable().Subscribe(_ => {
			DataManager.Instance.SetPlayerPencil(1);
			BlackBoardManager.Instance.ChangeCanvas(BlackBoardManager.ECanvasType.Battle);
			result.gameObject.SetActive(true);
			MySceneManager.Instance.ChangeScene(MySceneManager.ESceneType.Battle);
			battle.gameObject.SetActive(false);
			PositionManager.Instance.ChangePosition(0, 1);
		});

		result.OnClickAsObservable().Subscribe(_ => {
			BlackBoardManager.Instance.ChangeCanvas(BlackBoardManager.ECanvasType.Result);
			title.gameObject.SetActive(true);
			result.gameObject.SetActive(false);
		});
	}
}
