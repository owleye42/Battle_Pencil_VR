using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnUI : MonoBehaviour {

    [SerializeField]
    private Text turnText;

	// Use this for initialization
	void Start () {
        turnText.color = new Color(0f, 0f, 0f, 0f);

        ChangeText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeText()
    {
        if(BattleManager.Instance.ActiveController == OperatorManager.Instance.PlayerController) {
            turnText.text = "じぶんのターンです";
        }else if(BattleManager.Instance.ActiveController == OperatorManager.Instance.ComputerController) {
            turnText.text = "あいてのターンです";
        }

        StartCoroutine(TextDisplay());
    }

    IEnumerator TextDisplay()
    {
        turnText.color = new Color(0f, 0f, 0f, 1f);

        yield return new WaitForSeconds(1);

        turnText.color = new Color(0f, 0f, 0f, 0f);

        yield return null;
    }
}
