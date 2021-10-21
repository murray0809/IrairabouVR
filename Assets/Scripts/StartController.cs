using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    [SerializeField] GameObject m_startPos;

    void Start()
    {
        StartPos();
    }

    void StartPos()
    {
        m_startPos.GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stick")
        {
            m_startPos.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
