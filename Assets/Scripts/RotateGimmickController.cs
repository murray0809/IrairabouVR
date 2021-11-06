using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGimmickController : MonoBehaviour
{
    /// <summary> ��]�����邽�߂̒l�̕ϐ� </summary>
    [Header("��]�����邽�߂̒l")]
    [SerializeField] private Vector3 rotationVec;
    [Header("�U�����鑬��")]
    [SerializeField] private float AmplitudeSpeed;
    [Header("X�������Ɉړ�����U��")]
    [SerializeField] private float AmplitudeX;
    [Header("Y�������Ɉړ�����U��")]
    [SerializeField] private float AmplitudeY;
    [Header("Z�������Ɉړ�����U��")]
    [SerializeField] private float AmplitudeZ;
    [Header("��]�����邩�̃t���O")]
    public bool isRotate = false;
    [Header("�ړ������邩�̃t���O")]
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
            //��]
            transform.Rotate(new Vector3(rotationVec.x, rotationVec.y, rotationVec.z));
        }

        if (isMove)
        {
            GimmickMove();
        }
    }

    /// <summary>
    /// �ړ�����֐�
    /// </summary>
    private void GimmickMove()
    {
        transform.position = new Vector3((Mathf.Sin((Time.time) * AmplitudeSpeed) * AmplitudeX + startPos.x), 
                                         (Mathf.Sin((Time.time) * AmplitudeSpeed) * AmplitudeY + startPos.y), 
                                         (Mathf.Sin((Time.time) * AmplitudeSpeed) * AmplitudeZ + startPos.z));
    }
}
