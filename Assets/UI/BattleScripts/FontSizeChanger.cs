using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontSizeChanger : MonoBehaviour {
    [SerializeField] Text thisCountText;

    [SerializeField] int maxSize = 200; 
    [SerializeField] int middleSize =165;
    [SerializeField] int minSize = 134;
    public void Start()
    {
        thisCountText = this.GetComponent<Text>();
        thisCountText.text = " ";
    }
    public void SizeSetting()
    {

        thisCountText = this.GetComponent<Text>();

        if (thisCountText.text.Length < 11)
            thisCountText.fontSize = maxSize;
        else if (thisCountText.text.Length < 15)
            thisCountText.fontSize = middleSize;
        else
            thisCountText.fontSize = minSize;
    }
}
