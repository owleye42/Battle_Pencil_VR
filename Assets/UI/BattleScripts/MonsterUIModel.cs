using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MonsterUIModel {
    public Text HPText;
    public Slider HPBar;
    public Text[] skillTexts;
    public Image frame;
    public Image characterImage = null;
}
