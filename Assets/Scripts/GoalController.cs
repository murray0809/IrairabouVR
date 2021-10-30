using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField] GameObject goalPos;

    [SerializeField] StartController start;

    void Start()
    {
        GoalPos();
    }

    void GoalPos()
    {
        goalPos.GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stick" && start.Started)
        {
            goalPos.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
