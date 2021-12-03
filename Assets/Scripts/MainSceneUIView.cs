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

    const string titleScene = "Title";
    const string mainScene = "";
    const string rankingScene = "";

    void Start()
    {
        startButton.GetComponent<Button>().onClick.AddListener(PushStartButton);
        retryButton.GetComponent<Button>().onClick.AddListener(PushRetryButton);
        registButton.GetComponent<Button>().onClick.AddListener(PushRankingButton);
        ui.SetActive(false);
    }

    void DisplayClearUI()
    {
        ui.SetActive(true);
        uiText.text = "Clear\n" + "0.00";
        startButton.SetActive(true);
        registButton.SetActive(true);
    }

    void DisplayMissUI()
    {
        ui.SetActive(true);
        uiText.text = "Miss";
        startButton.SetActive(true);
        retryButton.SetActive(true);
    }

    void PushStartButton()
    {
        SceneManager.LoadScene(titleScene);
    }

    void PushRetryButton()
    {
        SceneManager.LoadScene(mainScene);
    }

    void PushRankingButton()
    {
        SceneManager.LoadScene(rankingScene);
    }
}
