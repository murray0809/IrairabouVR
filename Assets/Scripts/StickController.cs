using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    [SerializeField] GameObject stick;
    [SerializeField] GameObject rightController;

    [SerializeField] RetryController retryController;

    void Update()
    {
        Ray();
        if (retryController.IsRetry)
        {
            stick.SetActive(false);
        }
        else
        {
            stick.SetActive(true);
        }
    }

    void Ray()
    {
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
