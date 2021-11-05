using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickCollision : MonoBehaviour
{
    [SerializeField] GameObject stick;

    [SerializeField] StartController start;

    [SerializeField] RetryController retryController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" && start.Started)
        {
            stick.GetComponent<Renderer>().material.color = Color.red;

            StartCoroutine(Vivration(5f));

            retryController.ViewRetryUI();
        }
    }

    IEnumerator Vivration(float time)
    {
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);

        yield return new WaitForSeconds(time);

        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }
}
