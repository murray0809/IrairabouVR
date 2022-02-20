using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickController : MonoBehaviour
{
    [SerializeField] GameObject stick;

    [SerializeField] GameObject rightController;

    [SerializeField] GoalController goalController;

    [SerializeField] GameObject mainCamera;

    Vector2 leftStickValue;

    void Update()
    {
        Ray();

        if (goalController.IsGool)
        {
            stick.SetActive(false);
        }
        else if(!goalController.IsGool)
        {
            stick.SetActive(true);
        }

        leftStickValue = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        if (leftStickValue.y > 0)
        {
            Transform myTransform = mainCamera.transform;

            Vector3 myPos = myTransform.transform.position;

            myPos.y += 0.01f ;

            myTransform.transform.position = myPos;
        }
        else if (leftStickValue.y < 0)
        {
            Transform myTransform = mainCamera.transform;

            Vector3 myPos = myTransform.transform.position;

            myPos.y -= 0.01f;

            myTransform.transform.position = myPos;
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
