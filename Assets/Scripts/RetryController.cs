using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryController : MonoBehaviour
{
    [SerializeField] GameObject retryCanvas;

    [SerializeField] GameObject retryUI;

    [SerializeField] GameObject clearUI;

    [SerializeField] Button retryButton;

    [SerializeField] Button cancelButton;

    [SerializeField] string nextSceneName;

    const string titleScene = "Title";

    private bool isRetry = false;
    public bool IsRetry { get { return isRetry; } }

    void Start()
    {
        isRetry = false;
        retryButton.onClick.AddListener(OnPushRetryButton);
        cancelButton.onClick.AddListener(OnPushCancelButton);
        retryCanvas.SetActive(false);
    }

    void OnPushRetryButton()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    void OnPushCancelButton()
    {
        SceneManager.LoadScene(titleScene);
    }

    public void ViewRetryUI()
    {
        isRetry = true;
        retryCanvas.SetActive(true);
        clearUI.SetActive(false);
        retryUI.SetActive(true);
    }

    public void ViewClearUI()
    {
        retryCanvas.SetActive(true);
        retryUI.SetActive(false);
        clearUI.SetActive(true);
    }
}
