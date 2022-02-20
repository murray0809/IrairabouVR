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

    [SerializeField] GameObject effectPostion;

    [SerializeField] StageController stage;

    [SerializeField] AudioClip effectSound;

    [SerializeField] PointerController pointer;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        pointer.LineOff();
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.X))
        {
            debug = true;
            stick.GetComponent<Renderer>().material.color = Color.blue;
        }

        if (OVRInput.GetUp(OVRInput.RawButton.X))
        {
            debug = false;
            stick.GetComponent<Renderer>().material = stickMaterial;
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    stage.MoveStop();
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" && start.Started && !debug)
        {
            start.Finish();

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

        pointer.LineOn();

        mainSceneUIView.DisplayMissUI();
    }

    IEnumerator EffectOn()
    {
        Instantiate(effect, effectPostion.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(0.5f);

        Instantiate(effect, this.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(0.5f);

        Instantiate(effect, effectPostion.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(0.5f);

        Instantiate(effect, this.transform.position, Quaternion.identity);
    }

}
