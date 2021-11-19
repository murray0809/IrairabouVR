using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;

public class TitleSceneView : MonoBehaviour
{
    [SerializeField] Button startButton;
    //[SerializeField] Button rankingButton;

    TitleSceneViewModel viewModel;

    public void Initialize(TitleSceneViewModel viewModel)
    {
        this.viewModel = viewModel;
        startButton.onClick.AddListener(OnClickStartButton);
        //rankingButton.onClick.AddListener(OnClickKillNumberButton);

        viewModel.SceneMove.Subscribe(value =>
        {
            SceneManager.LoadScene(value);
        }).AddTo(this);
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
