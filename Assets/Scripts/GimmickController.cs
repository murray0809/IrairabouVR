using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickController : MonoBehaviour
{
    /// <summary> ��]�����邽�߂̒l�̕ϐ� </summary>
    [Header("��]�����邽�߂̒l")]
    [SerializeField] private Vector3 rotationVec;

    void Update()
    {
        transform.Rotate(new Vector3(rotationVec.x, rotationVec.y, rotationVec.z));
    }
}
