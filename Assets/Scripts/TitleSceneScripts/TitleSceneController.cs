using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneController : MonoBehaviour
{
    [SerializeField] TitleSceneView view;

    TitleSceneViewModel viewModel;

    void Start()
    {
        viewModel = new TitleSceneViewModel();

        view.Initialize(viewModel);
    }
}
