using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilPosReset : MonoBehaviour {
    [Header("自分の鉛筆")]
    [SerializeField] Pencil playerPencil;
    [Header("相手の鉛筆")]
    [SerializeField] Pencil CpuPencil;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Pencill"&&collision.gameObject.name== "Pencil(Player)")
        {
            collision.transform.position = playerPencil.InitPencilPos;
        }
        else if(collision.gameObject.tag == "Pencill" && collision.gameObject.name == "Pencil(CPU)") {
            collision.transform.position = CpuPencil.InitPencilPos;
        }
    }
}
