using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEffect : MonoBehaviour {
    [SerializeField]
    Vector3 AtackPosition;
    [SerializeField]
    float destryTime;
	

    public void CreateAtackEffect(string effectName)
    {
        EffectManager.Instance.CreateEffect(effectName,AtackPosition,destryTime);
    }
    
 }
