using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField] GameObject m_goalPos;

    void Start()
    {
        GoalPos();
    }

    void GoalPos()
    {
        m_goalPos.GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stick")
        {
            m_goalPos.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
