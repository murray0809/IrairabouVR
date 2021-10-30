using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickController : MonoBehaviour
{
    /// <summary> 回転させるための値の変数 </summary>
    [Header("回転させるための値")]
    [SerializeField] private Vector3 rotationVec;

    void Update()
    {
        transform.Rotate(new Vector3(rotationVec.x, rotationVec.y, rotationVec.z));
    }
}
