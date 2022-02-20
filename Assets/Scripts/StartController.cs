using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    [SerializeField] GameObject startPos;

    [SerializeField] GameObject stick;

    private float stickPosY;

    private bool started = false;
    public bool Started { get { return started; } }

    [SerializeField] AudioClip startSound;

    AudioSource audioSource;

    [SerializeField] GameObject mainCamera;

    void Start()
    {
        StartPos();

        started = false;

        audioSource = GetComponent<AudioSource>();
    }

    void StartPos()
    {
        startPos.GetComponent<Renderer>().material.color = Color.red;

        Transform myTransform = mainCamera.transform;

        Vector3 myPos = myTransform.transform.position;

        myPos.x = 0f;

        myPos.y = 0.8f;

        myPos.z = -2.5f;

        myTransform.transform.position = myPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        stickPosY = stick.transform.position.y;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Stick" && stickPosY > stick.transform.position.y)
        {
            audioSource.PlayOneShot(startSound);

            startPos.GetComponent<Renderer>().material.color = Color.green;

            started = true;

            FindObjectOfType<TimeCounter>().StartTimer();

            FindObjectOfType<BGMController>().StopBGM();

            FindObjectOfType<BGMController>().StartBGM2();
        }
    }

    public void Finish()
    {
        started = false;
    }
}
