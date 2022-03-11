/*
    File made by TGL(The Game Learner)
    Learning purpose
    v 1.0
*/

using System;
using System.Collections;
using System.Collections.Generic;
using TGLUtility.ObserverPattern;
using UnityEngine;

public class FloorObserverController
{
    private Transform _connectedToObj; // FloorObserverScript
    private MaterialColorChanger _colorChanger; // Material color Changer of the 
    private FloorData _floorsToRecolor;

	public FloorObserverController(IObservedObj subjectObj)
	{
        subjectObj.stateOfHandlerChanged += Subject_StateChanged;
	}

	private void Subject_StateChanged(ObsPtrnStateDemo obj)
	{
		_floorsToRecolor.SetActiveQuadWithMtl(obj.currentGlobalPosition, _colorChanger.activeMtl, _colorChanger.deactiveMtl);
	}

	public void SetConnectedGameObject(Transform connectedObj)
	{
		_connectedToObj = connectedObj;
		_colorChanger = connectedObj.GetComponent<MaterialColorChanger>();
		_floorsToRecolor = connectedObj.GetComponent<FloorData>();
		if (_colorChanger)
		{
			_colorChanger.ValidateData();
		}
	}
}