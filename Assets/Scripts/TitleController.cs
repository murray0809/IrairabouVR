using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    [SerializeField] Button startButton;

    [SerializeField] string nextSceneName;
    
    void Start()
    {
        startButton.onClick.AddListener(PushStartButton);
    }

    void PushStartButton()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
