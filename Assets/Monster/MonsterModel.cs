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

    [System.NonSerialized]
    public int maxHP;

    // カウンター用変数
    [System.NonSerialized]
    public bool isAttack = false;
    [System.NonSerialized]
    public int counterPower = 0;
}

[System.Serializable]
public enum Type {
    ATTACK,
    DEFENCE,
    HEAL
}
