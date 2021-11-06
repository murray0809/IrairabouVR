using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGimmickController : MonoBehaviour
{
    /// <summary> 回転させるための値の変数 </summary>
    [Header("回転させるための値")]
    [SerializeField] private Vector3 rotationVec;
    [Header("１周に必要な秒数")]
    [SerializeField] private float T;
    [Header("１秒あたりの周波数")]
    [SerializeField] private float F;
    [Header("回転させるかのフラグ")]
    public bool isRotate = false;
    [Header("移動させるかのフラグ")]
    public bool isMove = false;
    [Header("[X]が0、[Y]が1、[Z]が2")]
    public bool[] isMoveDirection;

    void Update()
    {
        if (isRotate)
        {
            //回転
            transform.Rotate(new Vector3(rotationVec.x, rotationVec.y, rotationVec.z));
        }
        
        if (isMove)
        {
            GimmickMove();
        }
    }

    /// <summary>
    /// 移動する関数
    /// </summary>
    private void GimmickMove()
    {
        if (isMoveDirection[0])
        {
            F = F / T;
            float SinX = Mathf.Sin(2 * Mathf.PI * F * Time.time);
            transform.position = new Vector3(SinX, 0, 0);
        }
        if (isMoveDirection[1])
        {
            F = F / T;
            float SinY = Mathf.Sin(2 * Mathf.PI * F * Time.time);
            transform.position = new Vector3(0, SinY, 0);
        }
        if (isMoveDirection[2])
        {
            F = F / T;
            float SinZ = Mathf.Sin(2 * Mathf.PI * F * Time.time);
            transform.position = new Vector3(0, 0, SinZ);
        }
    }
}
