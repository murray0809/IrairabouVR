using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    [SerializeField] GameObject startPos;

    void Start()
    {
        StartPos();
    }

    void StartPos()
    {
        startPos.GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stick")
        {
            startPos.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
