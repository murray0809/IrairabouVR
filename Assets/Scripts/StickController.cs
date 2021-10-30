using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    [SerializeField] GameObject stick;
    [SerializeField] GameObject rightController;

    [SerializeField] LineRenderer rayObject;

    void Update()
    {
        Ray();
    }

    void Ray()
    {
        rayObject.SetPosition(0, rightController.transform.position);
        rayObject.SetPosition(1, rightController.transform.position + rightController.transform.forward * 2f);

        rayObject.startWidth = 0.01f;
        rayObject.endWidth = 0.01f;

        stick.transform.position = Vector3.Lerp(rightController.transform.position,
            rightController.transform.position + rightController.transform.forward * 2f, 0.5f);

        StickRotation();
    }

    void StickRotation()
    {
        Transform controllerTransform = rightController.transform;

        stick.transform.rotation = controllerTransform.transform.rotation;

        stick.transform.Rotate(new Vector3(1, 0, 0), 90);
    }
}
