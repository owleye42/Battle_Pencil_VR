using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoardManager : BaseSingletonMono<BlackBoardManager> {
	
	[SerializeField]
	List<Sprite> standingSprite = new List<Sprite>();
	public List<Sprite> StandingSprite { get { return standingSprite; } }

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

		ChangeCanvas(ECanvasType.Title);
	}

	void Start() {

	}

	// Canvas切り替え
	public void ChangeCanvas(ECanvasType canvasType) {
		if (activeCanvas != null) {
			Destroy(activeCanvas);
		}

		canvasList.ForEach(cc => {
			if(canvasType == cc.type)
				activeCanvas = Instantiate(cc.prefCanvas);
		});
	}
}
