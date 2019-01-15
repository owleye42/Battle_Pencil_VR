using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : BaseSingletonMono<MonsterManager> {

	public BaseMonsterBehaviour PlayerMonsterBehaviour { get; set; }
	public BaseMonsterBehaviour ComputerMonsterBehaviour { get; set; }
}
