using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;

public class TitleSceneView : MonoBehaviour
{
    [SerializeField] Button startButton;

    [SerializeField] OVRScreenFade fade;

    TitleSceneViewModel viewModel;

    public void Initialize(TitleSceneViewModel viewModel)
    {
        this.viewModel = viewModel;
        startButton.onClick.AddListener(OnClickStartButton);

        viewModel.SceneMove.Subscribe(value =>
        {
            //fade.FadeOut();
            //SceneManager.LoadScene(value);
            StartCoroutine(MoveScene(value));
        }).AddTo(this);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(MoveScene("MainScene"));
        }
    }

    IEnumerator MoveScene(string sceneName)
    {
        yield return new WaitForSeconds(fade.fadeTime);

        SceneManager.LoadSceneAsync(sceneName);
    }

    public void OnClickStartButton()
    {
        viewModel.command.OnClickStartButton();
    }

    public void OnClickKillNumberButton()
    {
        viewModel.command.OnClickRankingButton();
    }
}
