using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGimmickController : MonoBehaviour
{
    /// <summary> ‰ñ“]‚³‚¹‚é‚½‚ß‚Ì’l‚Ì•Ï” </summary>
    [Header("‰ñ“]‚³‚¹‚é‚½‚ß‚Ì’l")]
    [SerializeField] private Vector3 rotationVec;
    [Header("‚Pü‚É•K—v‚È•b”")]
    [SerializeField] private float T;
    [Header("‚P•b‚ ‚½‚è‚Ìü”g”")]
    [SerializeField] private float F;
    [Header("‰ñ“]‚³‚¹‚é‚©‚Ìƒtƒ‰ƒO")]
    public bool isRotate = false;
    [Header("ˆÚ“®‚³‚¹‚é‚©‚Ìƒtƒ‰ƒO")]
    public bool isMove = false;
    [Header("[X]‚ª0A[Y]‚ª1A[Z]‚ª2")]
    public bool[] isMoveDirection;

    void Update()
    {
        if (isRotate)
        {
            //‰ñ“]
            transform.Rotate(new Vector3(rotationVec.x, rotationVec.y, rotationVec.z));
        }
        
        if (isMove)
        {
            GimmickMove();
        }
    }

    /// <summary>
    /// ˆÚ“®‚·‚éŠÖ”
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
