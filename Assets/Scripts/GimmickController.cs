using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// ギミックを動かす為のクラス
/// </summary>
public class GimmickController : MonoBehaviour
{
    /// <summary> 回転させるための値の変数 </summary>
    [Header("回転させるための値")]
    [SerializeField] private Vector3 rotationVec;
    /// <summary> 指定した値を回転させる時間の変数 </summary>
    [Header("指定した値を回転させる時間")]
    [SerializeField] private float RotationTime;
    /// <summary> 最初に移動する変数 </summary>
    [Header("最初に移動する値")]
    [SerializeField] private float StartMove;
    /// <summary> 最後に移動する変数 </summary>
    [Header("最後に移動する値")]
    [SerializeField] private float EndMove;
    /// <summary> 振幅する時間の変数 </summary>
    [Header("振幅する時間")]
    [SerializeField] private float AmplitudeSpeedTime;
    /// <summary> 遅延時間の変数 </summary>
    [Header("振幅を遅延させる時間")]
    [SerializeField] private float DelayTime;
    /// <summary> 回転させるかのフラグの変数 </summary>
    [Header("回転させるかのフラグ")]
    public bool isRotate = false;
    /// <summary> 移動させるかのフラグの変数 </summary>
    [Header("移動させるかのフラグ")]
    public bool isMove = false;
    /// <summary> 移動させる方向のフラグの変数 </summary>
    [Header("移動方向('X=0', 'Y=1', 'Z=2')")]
    public bool[] isMoveDirection;

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
            //回転
            DOTween.Sequence()
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
    }

    /// <summary>
    /// 移動する関数
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
}
