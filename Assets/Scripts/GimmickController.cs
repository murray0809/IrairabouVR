using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickController : MonoBehaviour
{
    /// <summary> 回転させるための値の変数 </summary>
    [Header("回転させるための値")]
    [SerializeField] private Vector3 rotationVec;
    /// <summary> 移動スピードの変数 </summary>
    [Header("移動スピード")]
    [SerializeField] private float moveSpeed;

    [Header("テスト用")]
    public bool isMove = false;

    void Update()
    {
        //回転
        transform.Rotate(new Vector3(rotationVec.x, rotationVec.y, rotationVec.z));

        if (isMove)
        {
            gameObject.transform.position += transform.position * moveSpeed * Time.deltaTime;
        }
    }

    //TODO:後日やる
    /// <summary>
    /// 移動を制限する関数
    /// </summary>
    private void GimmickMove()
    {
        
    }
}
