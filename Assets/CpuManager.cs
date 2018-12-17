using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpuManager : MonoBehaviour
{
    public static CpuManager instance = null;

    public GameObject monster;
    Animator animator;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public IEnumerator ThrowBall()
    {
        animator.CrossFade("ThrowBall",0);
        yield return null;
    }


}
    
