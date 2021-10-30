using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    [SerializeField] GameObject startPos;
    [SerializeField] GameObject stick;

    float stickPosY;

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
        stickPosY = stick.transform.position.y;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Stick" && stickPosY > stick.transform.position.y)
        {
            startPos.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
