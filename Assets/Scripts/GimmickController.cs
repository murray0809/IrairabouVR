using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// �M�~�b�N�𓮂����ׂ̃N���X
/// </summary>
public class GimmickController : MonoBehaviour
{
    /// <summary> ��]�����邽�߂̒l�̕ϐ� </summary>
    [Header("��]�����邽�߂̒l")]
    [SerializeField] private Vector3 rotationVec;
    /// <summary> �w�肵���l����]�����鎞�Ԃ̕ϐ� </summary>
    [Header("�w�肵���l����]�����鎞��")]
    [SerializeField] private float RotationTime;
    /// <summary> �ŏ��Ɉړ�����ϐ� </summary>
    [Header("�ŏ��Ɉړ�����l")]
    [SerializeField] private float StartMove;
    /// <summary> �Ō�Ɉړ�����ϐ� </summary>
    [Header("�Ō�Ɉړ�����l")]
    [SerializeField] private float EndMove;
    /// <summary> �U�����鎞�Ԃ̕ϐ� </summary>
    [Header("�U�����鎞��")]
    [SerializeField] private float AmplitudeSpeedTime;
    /// <summary> �x�����Ԃ̕ϐ� </summary>
    [Header("�U����x�������鎞��")]
    [SerializeField] private float DelayTime;
    /// <summary> ��]�����邩�̃t���O�̕ϐ� </summary>
    [Header("��]�����邩�̃t���O")]
    public bool isRotate = false;
    /// <summary> �ړ������邩�̃t���O�̕ϐ� </summary>
    [Header("�ړ������邩�̃t���O")]
    public bool isMove = false;
    /// <summary> �ړ�����������̃t���O�̕ϐ� </summary>
    [Header("�ړ�����('X=0', 'Y=1', 'Z=2')")]
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
            //��]
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
    /// �ړ�����֐�
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
