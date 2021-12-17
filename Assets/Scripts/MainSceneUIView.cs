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
    [SerializeField] GameObject registButton;

    [SerializeField] OVRScreenFade fade;

    const string titleScene = "Title";
    const string mainScene = "MainScene";
    const string rankingScene = "";

    void Start()
    {
        startButton.GetComponent<Button>().onClick.AddListener(PushStartButton);
        retryButton.GetComponent<Button>().onClick.AddListener(PushRetryButton);
        registButton.GetComponent<Button>().onClick.AddListener(PushRankingButton);
        startButton.SetActive(false);
        registButton.SetActive(false);
        retryButton.SetActive(false);
        ui.SetActive(false);

       
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DisplayMissUI();
            PushRetryButton();
            Debug.Log("test");
        }
    }

    public void DisplayClearUI()
    {
        ui.SetActive(true);
        uiText.text = "Clear\n" + Timer.CountTime.ToString("0.00");
        startButton.SetActive(true);
        registButton.SetActive(true);
    }

    public void DisplayMissUI()
    {
        ui.SetActive(true);
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

    void PushRankingButton()
    {
        StartCoroutine(MoveScene(rankingScene));
    }

    IEnumerator MoveScene(string sceneName)
    {
        yield return new WaitForSeconds(fade.fadeTime);

        SceneManager.LoadScene(sceneName);
    }
}
