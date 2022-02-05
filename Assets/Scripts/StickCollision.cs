using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickCollision : MonoBehaviour
{
    [SerializeField] GameObject stick;

    [SerializeField] StartController start;

    [SerializeField] float viveTime;

    [SerializeField] MainSceneUIView mainSceneUIView;

    private bool isRetry = false;
    public bool IsRetry => isRetry;

    private bool debug = false;

    [SerializeField] Material stickMaterial;

    [SerializeField] GameObject effect;

    [SerializeField] StageController stage;

    [SerializeField] AudioClip effectSound;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.A))
        {
            debug = true;
            stick.GetComponent<Renderer>().material.color = Color.blue;
        }

        if (OVRInput.GetUp(OVRInput.RawButton.A))
        {
            debug = false;
            stick.GetComponent<Renderer>().material = stickMaterial;
        }

        if (Input.GetMouseButtonDown(0))
        {
            stage.MoveStop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" && start.Started && !debug)
        {
            stage.MoveStop();

            StartCoroutine(EffectOn());

            StartCoroutine(Vivration(viveTime));

            StartCoroutine(ViewUI(2f));

            FindObjectOfType<TimeCounter>().StopTimer();

            FindObjectOfType<BGMController>().StopBGM();

            audioSource.PlayOneShot(effectSound);
        }
    }

    IEnumerator Vivration(float time)
    {
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);

        yield return new WaitForSeconds(time);

        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }

    IEnumerator ViewUI(float time)
    {
        yield return new WaitForSeconds(time);

        stick.SetActive(false);

        mainSceneUIView.DisplayMissUI();
    }

    IEnumerator EffectOn()
    {
        Instantiate(effect, this.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(0.5f);

        Instantiate(effect, this.transform.position, Quaternion.identity);
    }

}
