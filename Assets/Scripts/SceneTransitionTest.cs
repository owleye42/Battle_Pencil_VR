using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class SceneTransitionTest : MonoBehaviour {

	[SerializeField]
	Button titleButton;

	[SerializeField]
	Button selectButton;

	[SerializeField]
	Button battleButton;

	[SerializeField]
	Button resultButton;

	void Start () {
		titleButton.gameObject.SetActive(false);
		battleButton.gameObject.SetActive(false);
		resultButton.gameObject.SetActive(false);

		BlackBoardManager.Instance.ChangeCanvas(BlackBoardManager.ECanvasType.Title);
		selectButton.gameObject.SetActive(true);
		MySceneManager.Instance.ChangeScene(MySceneManager.ESceneType.Title);
		PositionManager.Instance.ChangePosition(0, 0);

		titleButton.OnClickAsObservable().Subscribe(_ => {
			titleButton.gameObject.SetActive(false);
			selectButton.gameObject.SetActive(true);
			BlackBoardManager.Instance.ChangeCanvas(BlackBoardManager.ECanvasType.Title);
			MySceneManager.Instance.ChangeScene(MySceneManager.ESceneType.Title);
			PositionManager.Instance.ChangePosition(0, 0);
		});

		selectButton.OnClickAsObservable().Subscribe(_ => {
			BlackBoardManager.Instance.ChangeCanvas(BlackBoardManager.ECanvasType.Select);
			battleButton.gameObject.SetActive(true);
			selectButton.gameObject.SetActive(false);
		});

		battleButton.OnClickAsObservable().Subscribe(_ => {
			Fade_In_Out.Instance.StartFade(1, 3, 1, () => {
				battleButton.gameObject.SetActive(false);
				resultButton.gameObject.SetActive(true);
				DataManager.Instance.SetPlayerPencil(1);
				BlackBoardManager.Instance.ChangeCanvas(BlackBoardManager.ECanvasType.Battle);
				MySceneManager.Instance.ChangeScene(MySceneManager.ESceneType.Battle);
				PositionManager.Instance.ChangePosition(0, 1);
			});
		});

		resultButton.OnClickAsObservable().Subscribe(_ => {
			BlackBoardManager.Instance.ChangeCanvas(BlackBoardManager.ECanvasType.Result);
			titleButton.gameObject.SetActive(true);
			resultButton.gameObject.SetActive(false);
		});
	}

	IEnumerator FadeCoroutine() {
		DataManager.Instance.SetPlayerPencil(1);
		BlackBoardManager.Instance.ChangeCanvas(BlackBoardManager.ECanvasType.Battle);
		resultButton.gameObject.SetActive(true);
		MySceneManager.Instance.ChangeScene(MySceneManager.ESceneType.Battle);
		battleButton.gameObject.SetActive(false);
		PositionManager.Instance.ChangePosition(0, 1);
		yield return new WaitForSeconds(3);
	}
}
