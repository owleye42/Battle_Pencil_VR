using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoardManager : BaseSingletonMono<BlackBoardManager> {

	[System.Serializable]
	public enum ECanvasType {
		Title, Select, Battle, Result
	}

	[System.Serializable]
	public class CanvasContainer {
		public ECanvasType type;
		public GameObject prefCanvas;
	}

	[SerializeField]
	List<CanvasContainer> canvasList = new List<CanvasContainer>();

	GameObject activeCanvas = null;

	protected override void Awake() {
		base.Awake();

		SwitchCanvas(ECanvasType.Title);
	}

	void Start() {

	}

	// Canvas切り替え
	public void SwitchCanvas(ECanvasType canvasType) {
		if (activeCanvas != null) {
			Destroy(activeCanvas);
		}

		canvasList.ForEach(cc => {
			if(canvasType == cc.type)
				Instantiate(cc.prefCanvas);
		});
	}
}
