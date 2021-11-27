using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PipeMoveController : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField] Vector3 endPos;
    /// <summary> StartPosからEadPosに移動する時間 </summary>
    [SerializeField] float moveTime = 2f;
    /// <summary> 移動のループ回数（適当に1000入れた) </summary>
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
    /// 移動する
    /// </summary>
    void Move()
    {
        this.transform.DOMove(endPos, moveTime).SetLoops(roopCount, LoopType.Yoyo);
    }
}
