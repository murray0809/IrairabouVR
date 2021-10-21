using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    [SerializeField] GameObject m_stick;
    [SerializeField] GameObject m_rightController;

    [SerializeField] LineRenderer m_rayObject;

    void Update()
    {
        Ray();
    }

    void Ray()
    {
        m_rayObject.SetPosition(0, m_rightController.transform.position);
        m_rayObject.SetPosition(1, m_rightController.transform.position + m_rightController.transform.forward * 2f);

        m_rayObject.startWidth = 0.01f;
        m_rayObject.endWidth = 0.01f;

        m_stick.transform.position = Vector3.Lerp(m_rightController.transform.position,
            m_rightController.transform.position + m_rightController.transform.forward * 2f, 0.5f);

        StickRotation();
    }

    void StickRotation()
    {
        Transform controllerTransform = m_rightController.transform;

        m_stick.transform.rotation = controllerTransform.transform.rotation;

        m_stick.transform.Rotate(new Vector3(1, 0, 0), 90);
    }
}
