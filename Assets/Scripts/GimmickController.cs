using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickController : MonoBehaviour
{
    /// <summary> ��]�����邽�߂̒l�̕ϐ� </summary>
    [Header("��]�����邽�߂̒l")]
    [SerializeField] private Vector3 rotationVec;
    /// <summary> �ړ��X�s�[�h�̕ϐ� </summary>
    [Header("�ړ��X�s�[�h")]
    [SerializeField] private float moveSpeed;

    [Header("�e�X�g�p")]
    public bool isMove = false;

    void Update()
    {
        //��]
        transform.Rotate(new Vector3(rotationVec.x, rotationVec.y, rotationVec.z));

        if (isMove)
        {
            gameObject.transform.position += transform.position * moveSpeed * Time.deltaTime;
        }
    }

    //TODO:������
    /// <summary>
    /// �ړ��𐧌�����֐�
    /// </summary>
    private void GimmickMove()
    {
        
    }
}
