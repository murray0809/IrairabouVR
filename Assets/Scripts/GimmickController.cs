using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickController : MonoBehaviour
{
    /// <summary> ‰ñ“]‚³‚¹‚é‚½‚ß‚Ì’l‚Ì•Ï” </summary>
    [Header("‰ñ“]‚³‚¹‚é‚½‚ß‚Ì’l")]
    [SerializeField] private Vector3 rotationVec;
    /// <summary> U•‚·‚é‘¬‚³‚Ì•Ï” </summary>
    [Header("U•‚·‚é‘¬‚³")]
    [SerializeField] private float AmplitudeSpeed;
    /// <summary> X²•ûŒü‚ÉˆÚ“®‚·‚éU•‚Ì•Ï” </summary>
    [Header("X²•ûŒü‚ÉˆÚ“®‚·‚éU•")]
    [SerializeField] private float AmplitudeX;
    /// <summary> Y²•ûŒü‚ÉˆÚ“®‚·‚éU•‚Ì•Ï” </summary>
    [Header("Y²•ûŒü‚ÉˆÚ“®‚·‚éU•")]
    [SerializeField] private float AmplitudeY;
    /// <summary> Z²•ûŒü‚ÉˆÚ“®‚·‚éU•‚Ì•Ï” </summary>
    [Header("Z²•ûŒü‚ÉˆÚ“®‚·‚éU•")]
    [SerializeField] private float AmplitudeZ;
    /// <summary> ‰ñ“]‚³‚¹‚é‚©‚Ìƒtƒ‰ƒO‚Ì•Ï” </summary>
    [Header("‰ñ“]‚³‚¹‚é‚©‚Ìƒtƒ‰ƒO")]
    public bool isRotate = false;
    /// <summary> ˆÚ“®‚³‚¹‚é‚©‚Ìƒtƒ‰ƒO‚Ì•Ï” </summary>
    [Header("ˆÚ“®‚³‚¹‚é‚©‚Ìƒtƒ‰ƒO")]
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
        transform.position = new Vector3((Mathf.Sin((Time.time) * AmplitudeSpeed) * AmplitudeX + startPos.x), 
                                         (Mathf.Sin((Time.time) * AmplitudeSpeed) * AmplitudeY + startPos.y), 
                                         (Mathf.Sin((Time.time) * AmplitudeSpeed) * AmplitudeZ + startPos.z));
    }
}
