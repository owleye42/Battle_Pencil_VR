using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MonsterModel {

    public int id;
	public string name;

    public int hp;
    public Type type;
	public List<SkillModel> skillList;
    public GameObject pref;
}

[System.Serializable]
public enum Type {
    ATTACK,
    DEFENCE,
    HEAL
}
