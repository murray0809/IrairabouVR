using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGimmickController : MonoBehaviour
{
    /// <summary> ��]�����邽�߂̒l�̕ϐ� </summary>
    [Header("��]�����邽�߂̒l")]
    [SerializeField] private Vector3 rotationVec;
    [Header("�P���ɕK�v�ȕb��")]
    [SerializeField] private float T;
    [Header("�P�b������̎��g��")]
    [SerializeField] private float F;
    [Header("��]�����邩�̃t���O")]
    public bool isRotate = false;
    [Header("�ړ������邩�̃t���O")]
    public bool isMove = false;
    [Header("[X]��0�A[Y]��1�A[Z]��2")]
    public bool[] isMoveDirection;

    void Update()
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
