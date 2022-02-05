using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    [SerializeField] GameObject goalPos;

    [SerializeField] StartController start;

    [SerializeField] MainSceneUIView mainSceneUIView;

    [SerializeField] AudioClip goalSound;

    AudioSource audioSource;

    private bool isGool = false;
    public bool IsGool { get { return isGool; } }

    [SerializeField] OVRScreenFade fade;

    void Start()
    {
        GoalPos();

        audioSource = GetComponent<AudioSource>();
    }

    void GoalPos()
    {
        goalPos.GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stick" && start.Started)
        {
            isGool = true;

            goalPos.GetComponent<Renderer>().material.color = Color.green;
            
            mainSceneUIView.DisplayClearUI();

            FindObjectOfType<TimeCounter>().StopTimer();

            UserDatas.Instans.AddUserData(new UserData("noname", Timer.CountTime));
            
            FindObjectOfType<BGMController>().StopBGM();

            audioSource.PlayOneShot(goalSound);
        }
    }
}
