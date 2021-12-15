using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    [SerializeField] GameObject goalPos;

    [SerializeField] StartController start;

    //[SerializeField] RetryController retryController;

    //[SerializeField] Button registButton;

    //[SerializeField] Button cancelButton;

    //[SerializeField] string nextSceneName;

    //[SerializeField] Text clearText;

    [SerializeField] MainSceneUIView mainSceneUIView;

    private bool isGool = false;
    public bool IsGool { get { return isGool; } }

    //const string titleScene = "Title";

    [SerializeField] OVRScreenFade fade;

    void Start()
    {
        GoalPos();
        //registButton.onClick.AddListener(OnPushRegistButton);
        //cancelButton.onClick.AddListener(OnPushCancelButton);
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
            //retryController.ViewClearUI();
            mainSceneUIView.DisplayClearUI();
            FindObjectOfType<TimeCounter>().StopTimer();
            //clearText.text = "Clear\n" + FindObjectOfType<TimeCounter>().timer.CountTime.ToString("0.00");
        }
    }

    //void OnPushRegistButton()
    //{
    //    SceneManager.LoadScene(nextSceneName);
    //}

    //void OnPushCancelButton()
    //{
    //    fade.FadeOut();

    //    StartCoroutine(MoveTitleScene());
    //}

    //IEnumerator MoveTitleScene()
    //{
    //    yield return new WaitForSeconds(fade.fadeTime);

    //    SceneManager.LoadScene(titleScene);
    //}
}
