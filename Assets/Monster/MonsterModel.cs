using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MonsterModel {
	public int id;
	//public GameObject prefab;
	public string name;
	public int hp;
	//public int attack;
	public List<SkillModel> skillList;
}
