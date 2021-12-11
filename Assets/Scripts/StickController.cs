using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    [SerializeField] GameObject stick;
    [SerializeField] GameObject rightController;

    //[SerializeField] RetryController retryController;

    [SerializeField] GoalController goalController;

    void Update()
    {
        Ray();

        if (/*retryController.IsRetry ||*/goalController.IsGool)
        {
            stick.SetActive(false);
        }
        else if(/*!retryController.IsRetry || */!goalController.IsGool)
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
