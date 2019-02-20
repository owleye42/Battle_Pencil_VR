using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEffect : MonoBehaviour {
    [SerializeField]
    Transform AtackPosition;
    [SerializeField]
    float destryTime;
	

    public void CreateAtackEffect(string effectName)
    {
        EffectManager.Instance.CreateEffect(effectName,AtackPosition.position,destryTime);
    }
    
 }
