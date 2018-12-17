using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum SkillType {
	Attack,
	Heal,
	Miss,
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
	public int power;
	public string text;
}