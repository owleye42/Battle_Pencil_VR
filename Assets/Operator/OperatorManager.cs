using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorManager : BaseSingletonMono<OperatorManager> {

	public OperatorController PlayerController { get; set; }
	public OperatorController ComputerController { get; set; }
}
