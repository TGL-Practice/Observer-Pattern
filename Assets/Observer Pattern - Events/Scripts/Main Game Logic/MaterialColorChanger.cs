/*
    File made by TGL(The Game Learner)
    Learning purpose
    v 1.0
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColorChanger : MonoBehaviour
{
    public Material activeMtl, deactiveMtl;
	private Renderer _renderer;
	private bool _isValidated = true;
	public void ValidateData()
	{
		if(activeMtl == null || deactiveMtl == null)
		{
			Debug.LogError("Material not assigned in " + transform.name, transform);
			_isValidated = false;
		}

		_renderer = GetComponent<Renderer>();
		if (_renderer == null)
		{
			Debug.LogError("No renderer found for this gameobject", transform);
			_isValidated = false;
		}

		if (!_isValidated)
		{
			Destroy(this);
		}
	}

	public void ActivateMtl()
	{
		if (!_isValidated)
		{
			return;
		}

		if (_renderer.sharedMaterial == deactiveMtl)
		{
			_renderer.material = activeMtl;
		}
	}

	public void DeactivateMtl()
	{
		if (!_isValidated)
		{
			return;
		}
		if (_renderer.sharedMaterial == activeMtl)
		{
			_renderer.material = deactiveMtl;
		}
	}
}