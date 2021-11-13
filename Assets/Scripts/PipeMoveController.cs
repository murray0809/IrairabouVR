using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PipeMoveController : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField] Vector3 endPos;
    /// <summary> StartPos����EadPos�Ɉړ����鎞�� </summary>
    [SerializeField] float moveTime = 2f;
    /// <summary> �ړ��̃��[�v�񐔁i�K����1000���ꂽ) </summary>
    [SerializeField] int roopCount = 1000;

    void Awake()
    {
        startPos = this.transform.position;
    }

    void Start()
    {
        //Move();
    }

    /// <summary>
    /// �ړ�����
    /// </summary>
    void Move()
    {
        this.transform.DOMove(endPos, moveTime).SetLoops(roopCount, LoopType.Yoyo);
    }
}
