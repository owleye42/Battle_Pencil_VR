using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle {

	[System.Serializable]
	public enum SkillType {
		Attack,
		Heal,
		None,
	}

	[System.Serializable]
	public enum TargetType {
		One,
		All,
		None,
	}

	[System.Serializable]
	public class SkillModel {
		public SkillType skillType;
		public TargetType targetType;
		public int basePower;
	}
}