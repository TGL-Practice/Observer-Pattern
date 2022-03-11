/*
    File made by TGL(The Game Learner)
    Learning purpose
    v 1.0
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformConverter : MonoBehaviour
{
    public Transform originTransform;

    /// <summary>
    /// Finds current Object posiion with respect to the originTransform position
    /// </summary>
    [ContextMenu(nameof(Calculate))]
    public void Calculate()
	{
        Debug.Log(originTransform.InverseTransformPoint(transform.position));
	}
}