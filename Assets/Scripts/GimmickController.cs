using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickController : MonoBehaviour
{
    /// <summary> ��]�����邽�߂̒l�̕ϐ� </summary>
    [Header("��]�����邽�߂̒l")]
    [SerializeField] private Vector3 rotationVec;
    /// <summary> �U�����鑬���̕ϐ� </summary>
    [Header("�U�����鑬��")]
    [SerializeField] private float AmplitudeSpeed;
    /// <summary> X�������Ɉړ�����U���̕ϐ� </summary>
    [Header("X�������Ɉړ�����U��")]
    [SerializeField] private float AmplitudeX;
    /// <summary> Y�������Ɉړ�����U���̕ϐ� </summary>
    [Header("Y�������Ɉړ�����U��")]
    [SerializeField] private float AmplitudeY;
    /// <summary> Z�������Ɉړ�����U���̕ϐ� </summary>
    [Header("Z�������Ɉړ�����U��")]
    [SerializeField] private float AmplitudeZ;
    /// <summary> ��]�����邩�̃t���O�̕ϐ� </summary>
    [Header("��]�����邩�̃t���O")]
    public bool isRotate = false;
    /// <summary> �ړ������邩�̃t���O�̕ϐ� </summary>
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
