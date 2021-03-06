﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : BaseSingletonMono<PositionManager> {

	[System.Serializable]
	public class ObjPosContainer {
		public GameObject obj;
		public List<Vector3> posList;
	}

	[SerializeField]
	List<ObjPosContainer> objPosContainers;

	public void ChangePosition(int containerIndex, int posIndex) {
		var container = objPosContainers[containerIndex];
		container.obj.transform.position = container.posList[posIndex];
	}
}
