using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryController : MonoBehaviour
{
    [SerializeField] GameObject retryUI;

    [SerializeField] Button retryButton;

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
        SceneManager.LoadScene(0);
    }

    public void ViewRetryUI()
    {
        isRetry = true;
        retryUI.SetActive(true);
    }
}
