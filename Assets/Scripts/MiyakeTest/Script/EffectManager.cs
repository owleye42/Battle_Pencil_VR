using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

    public static EffectManager Instance;

    string nextBgmName;

   
    //Effect保存用
    Dictionary<string, GameObject> effects;
 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        if (Instance != this)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        effects = new Dictionary<string, GameObject>();
       
        object[] effectList = Resources.LoadAll("Effect");
       
        foreach (GameObject effect in effectList)
        {
            effects[effect.name] = effect;
            Debug.Log("eddebr"+effect.name);
        }
    }

     public IEnumerator CreateEffect(string effectName,Vector3 createPosition,float destryTime)
    {
        if (!effects.ContainsKey(effectName))
        {
            Debug.Log("その名前のエフェクはありません。");
            yield return null;
        }

        var effect = Instantiate<GameObject>(effects[effectName]as GameObject);
        effect.transform.position = createPosition;
        Destroy(effect,destryTime);
        yield return null;
    }

    
    
}
