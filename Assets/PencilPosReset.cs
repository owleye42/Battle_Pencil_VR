using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilPosReset : MonoBehaviour {
    [SerializeField] Pencil playerPencil;
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
