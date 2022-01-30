using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
	private GimmickController[] cols;

	void Start()
	{
		cols = GetComponentsInChildren<GimmickController>();
	}

	public void MoveStop()
    {
		foreach (var col in cols)
		{
			col.MoveStop();
		}
	}
}
