using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    //CapsuleCollider playerCol;

    private void Start()
    {
        //playerCol.GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log(col.tag + "감지");
        }
        else if (col.tag == "Range")
        {
            Debug.Log(col.tag + "감지");
        }
    }
}
