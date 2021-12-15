using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TitleSceneViewModel
{
    //データ類の保持/管理
    public Command command;

    Subject<string> sceneMove = new Subject<string>();
    public IObservable<string> SceneMove => sceneMove;

    const string mainScene = "MainScene";

    public TitleSceneViewModel()
    {
        command = new Command(this);
    }

    //処理などのロジック類の定義
    public class Command
    {
        TitleSceneViewModel viewModel;

        public Command(TitleSceneViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public void OnClickStartButton()
        {
            viewModel.sceneMove.OnNext(mainScene);
        }

        public void OnClickRankingButton()
        {
            viewModel.sceneMove.OnNext("");
        }
    }
}
