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

		title.OnClickAsObservable().Subscribe(_ => {
			BlackBoardManager.Instance.ChangeCanvas(BlackBoardManager.ECanvasType.Title);
			select.gameObject.SetActive(true);
			MySceneManager.Instance.ChangeScene(MySceneManager.ESceneType.Title);
			title.gameObject.SetActive(false);
		});

		select.OnClickAsObservable().Subscribe(_ => {
			BlackBoardManager.Instance.ChangeCanvas(BlackBoardManager.ECanvasType.Select);
			battle.gameObject.SetActive(true);
			select.gameObject.SetActive(false);
		});

		battle.OnClickAsObservable().Subscribe(_ => {
			DataManager.Instance.SetPlayerPencil(1);
			result.gameObject.SetActive(true);
			MySceneManager.Instance.ChangeScene(MySceneManager.ESceneType.Battle);
			battle.gameObject.SetActive(false);
		});

		result.OnClickAsObservable().Subscribe(_ => {
			BlackBoardManager.Instance.ChangeCanvas(BlackBoardManager.ECanvasType.Result);
			title.gameObject.SetActive(true);
			result.gameObject.SetActive(false);
		});
	}
}
