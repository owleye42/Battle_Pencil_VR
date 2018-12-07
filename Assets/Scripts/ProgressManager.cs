using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : BaseSingletonMono<ProgressManager> {

	public delegate void MouseClickHandler();
	public event MouseClickHandler OnClick;

	readonly ActionContext context = new ActionContext();

	private void Update() {
		context.ExecuteUpdate();
	}
}
