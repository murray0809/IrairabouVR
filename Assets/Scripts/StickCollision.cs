using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickCollision : MonoBehaviour
{
    [SerializeField] GameObject stick;

    bool test = false;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            test = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" && test)
        {
            stick.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
