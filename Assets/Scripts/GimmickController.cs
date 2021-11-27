using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickController : MonoBehaviour
{
    /// <summary> 回転させるための値の変数 </summary>
    [Header("回転させるための値")]
    [SerializeField] private Vector3 rotationVec;
    /// <summary> 振幅する速さの変数 </summary>
    [Header("振幅する速さ")]
    [SerializeField] private float AmplitudeSpeed;
    /// <summary> X軸方向に移動する振幅の変数 </summary>
    [Header("X軸方向に移動する振幅")]
    [SerializeField] private float AmplitudeX;
    /// <summary> Y軸方向に移動する振幅の変数 </summary>
    [Header("Y軸方向に移動する振幅")]
    [SerializeField] private float AmplitudeY;
    /// <summary> Z軸方向に移動する振幅の変数 </summary>
    [Header("Z軸方向に移動する振幅")]
    [SerializeField] private float AmplitudeZ;
    /// <summary> 回転させるかのフラグの変数 </summary>
    [Header("回転させるかのフラグ")]
    public bool isRotate = false;
    /// <summary> 移動させるかのフラグの変数 </summary>
    [Header("移動させるかのフラグ")]
    public bool isMove = false;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void FixedUpdate()
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
        transform.position = new Vector3((Mathf.Sin((Time.time) * AmplitudeSpeed) * AmplitudeX + startPos.x), 
                                         (Mathf.Sin((Time.time) * AmplitudeSpeed) * AmplitudeY + startPos.y), 
                                         (Mathf.Sin((Time.time) * AmplitudeSpeed) * AmplitudeZ + startPos.z));
    }
}
