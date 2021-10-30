using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickController : MonoBehaviour
{
    /// <summary> ‰ñ“]‚³‚¹‚é‚½‚ß‚Ì’l‚Ì•Ï” </summary>
    [Header("‰ñ“]‚³‚¹‚é‚½‚ß‚Ì’l")]
    [SerializeField] private Vector3 rotationVec;

    void Update()
    {
        transform.Rotate(new Vector3(rotationVec.x, rotationVec.y, rotationVec.z));
    }
}
