using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryController : MonoBehaviour
{
    [SerializeField] GameObject retryUI;

    [SerializeField] Button retryButton;

    [SerializeField] string nextSceneName;

    private bool isRetry = false;
    public bool IsRetry { get { return isRetry; } }

    void Start()
    {
        isRetry = false;
        retryButton.onClick.AddListener(OnPushRetryButton);
        retryUI.SetActive(false);
    }

    void OnPushRetryButton()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void ViewRetryUI()
    {
        isRetry = true;
        retryUI.SetActive(true);
    }
}
