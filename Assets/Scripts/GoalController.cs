using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField] GameObject goalPos;

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
        if (collision.gameObject.tag == "Stick")
        {
            goalPos.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
