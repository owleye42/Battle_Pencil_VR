using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MonsterUIModel {
    public int monsterMaxHP;
    public Text HPText;
    public Image HPBar;
    public Text[] skillTexts;
    public Image frame;
}
