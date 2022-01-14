using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// ?M?~?b?N?????????????N???X
/// </summary>
public class GimmickController : MonoBehaviour
{
    /// <summary> ???]?????????????l?????? </summary>
    [Header("???]?????????????l")]
    [SerializeField] private Vector3 rotationVec;
    /// <summary> ?w???????l?????]???????????????? </summary>
    [Header("?w???????l?????]??????????")]
    [SerializeField] private float RotationTime;
    /// <summary> ?????????????????? </summary>
    [Header("???????????????l")]
    [SerializeField] private float StartMove;
    /// <summary> ?????????????????? </summary>
    [Header("???????????????l")]
    [SerializeField] private float EndMove;
    /// <summary> ?U???????????????? </summary>
    [Header("?U??????????")]
    [SerializeField] private float AmplitudeSpeedTime;
    /// <summary> ?x???????????? </summary>
    [Header("?U?????x????????????")]
    [SerializeField] private float DelayTime;
    /// <summary> ???]???????????t???O?????? </summary>
    [Header("???]???????????t???O")]
    [SerializeField] bool isRotate = false;
    /// <summary> ???????????????t???O?????? </summary>
    [Header("???????????????t???O")]
    [SerializeField] bool isMove = false;
    /// <summary> ?????????????????t???O?????? </summary>
    [Header("????????('X=0', 'Y=1', 'Z=2')")]
    public bool[] isMoveDirection;

    private bool stop = false;
    public bool Stop { get { return stop; } set { stop = value; } }

    private void Awake()
    {
        gameObject.transform.position = gameObject.transform.position;

        if (isMove)
        {
            StartCoroutine(GimmickCoroutine());
        }
    }

    private void FixedUpdate()
    {
        if (isRotate)
        {
            //???]
            Tween t = DOTween.Sequence()
                .Append(gameObject.transform.DORotate(new Vector3(rotationVec.x, rotationVec.y, rotationVec.z),
                        RotationTime, RotateMode.WorldAxisAdd))
                .SetLoops(-1, LoopType.Yoyo)
                .Play();
        }
    }

    IEnumerator GimmickCoroutine()
    {
        GimmickMove();
        yield return null;

        if (!isMove)
        {
            yield break;
        }
    }

    /// <summary>
    /// ????????????
    /// </summary>
    void GimmickMove()
    {
        //X
        if (isMoveDirection[0] == true)
        {
            DOTween.Sequence()
            .Append(gameObject.transform.DOMoveX(StartMove, AmplitudeSpeedTime)
            .SetDelay(DelayTime)
            .SetEase(Ease.Linear))
            .SetLoops(-1, LoopType.Yoyo)
            .Append(gameObject.transform.DOMoveX(EndMove, AmplitudeSpeedTime)
            .SetDelay(DelayTime)
            .SetEase(Ease.Linear))
            .SetLoops(-1, LoopType.Yoyo)
            .Play();
        }

        //Y
        if (isMoveDirection[1] == true)
        {
            DOTween.Sequence()
            .Append(gameObject.transform.DOMoveY(StartMove, AmplitudeSpeedTime)
            .SetDelay(DelayTime)
            .SetEase(Ease.Linear))
            .SetLoops(-1, LoopType.Yoyo)
            .Append(gameObject.transform.DOMoveY(EndMove, AmplitudeSpeedTime)
            .SetDelay(DelayTime)
            .SetEase(Ease.Linear))
            .SetLoops(-1, LoopType.Yoyo)
            .Play();
        }

        //Z
        if (isMoveDirection[2] == true)
        {
            DOTween.Sequence()
            .Append(gameObject.transform.DOMoveZ(StartMove, AmplitudeSpeedTime)
            .SetDelay(DelayTime)
            .SetEase(Ease.Linear))
            .SetLoops(-1, LoopType.Yoyo)
            .Append(gameObject.transform.DOMoveZ(EndMove, AmplitudeSpeedTime)
            .SetDelay(DelayTime)
            .SetEase(Ease.Linear))
            .SetLoops(-1, LoopType.Yoyo)
            .Play();
        }
    }

    public void MoveStop()
    {
        isRotate = false;
        DOTween.KillAll();
    }
}
