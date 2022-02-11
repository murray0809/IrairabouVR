using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    [SerializeField] LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    public void LineOn()
    {
        line.enabled = true;
    }

    public void LineOff()
    {
        line.enabled = false;
    }
}
