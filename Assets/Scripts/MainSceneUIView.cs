using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneUIView : MonoBehaviour
{
    [SerializeField] GameObject ui;
    [SerializeField] Text uiText;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject retryButton;
    
    [SerializeField] OVRScreenFade fade;

    [SerializeField] GameObject mainCamera;

    const string titleScene = "Title";
    const string mainScene = "MainScene";

    void Start()
    {
        startButton.GetComponent<Button>().onClick.AddListener(PushStartButton);
        retryButton.GetComponent<Button>().onClick.AddListener(PushRetryButton);
        startButton.SetActive(false);
        retryButton.SetActive(false);
        ui.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(MoveScene(titleScene));
        }
    }

    public void DisplayClearUI()
    {
        ui.SetActive(true);
        UIPostion();
        uiText.text = "Clear\n" + Timer.CountTime.ToString("0.00");
        startButton.SetActive(true);
    }

    public void DisplayMissUI()
    {
        ui.SetActive(true);
        UIPostion();
        uiText.text = "Miss";
        startButton.SetActive(true);
        retryButton.SetActive(true);
    }

    void PushStartButton()
    {
        fade.FadeOut();
        StartCoroutine(MoveScene(titleScene));
    }

    void PushRetryButton()
    {
        fade.FadeOut();
        StartCoroutine(MoveScene(mainScene));
    }

    IEnumerator MoveScene(string sceneName)
    {
        yield return new WaitForSeconds(fade.fadeTime);

        SceneManager.LoadSceneAsync(sceneName);
    }

    void UIPostion()
    {
        float angle = mainCamera.transform.localEulerAngles.y;

        if (angle < 315f && angle <= 45f)
        {
            Transform myTransform = this.transform;

            Vector3 myPos = this.transform.position;

            myPos.x = 1.8f;

            myPos.y = -0.8f;

            myPos.z = -2.4f;

            myTransform.transform.position = myPos;

            Vector3 localAngle = myTransform.localEulerAngles;

            localAngle.y = 0;

            myTransform.localEulerAngles = localAngle;
        }
        else if (angle > 45f && angle <= 135f)
        {
            Transform myTransform = this.transform;

            Vector3 myPos = this.transform.position;

            myPos.x = 0;

            myPos.y = -0.8f;

            myPos.z = -3.8f;

            myTransform.transform.position = myPos;

            Vector3 localAngle = myTransform.localEulerAngles;

            localAngle.y = 90f;

            myTransform.localEulerAngles = localAngle;
        }
        else if (angle > 135f && angle <= 225f)
        {
            Transform myTransform = this.transform;

            Vector3 myPos = this.transform.position;

            myPos.x = -1.3f;

            myPos.y = -0.8f;

            myPos.z = -2.2f;

            myTransform.transform.position = myPos;

            Vector3 localAngle = myTransform.localEulerAngles;

            localAngle.y = 180f;

            myTransform.localEulerAngles = localAngle;
        }
        else if (angle > 225f && angle <= 315f)
        {
            Transform myTransform = this.transform;

            Vector3 myPos = this.transform.position;

            myPos.x = 0.4f;

            myPos.y = -0.8f;

            myPos.z = -0.8f;

            myTransform.transform.position = myPos;

            Vector3 localAngle = myTransform.localEulerAngles;

            localAngle.y = 270f;

            myTransform.localEulerAngles = localAngle;
        }
    }
}
