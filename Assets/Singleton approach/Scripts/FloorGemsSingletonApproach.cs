/*
    File made by TGL(The Game Learner)
    Learning purpose
    v 1.0
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGemsSingletonApproach : MonoBehaviour
{
    //set in inspector
    public Material playerActiveMtl;
    public Material playerDeactiveMtl;
	public DirectionEnums detectionAxis;

	//private
	private Renderer myRenderer;
	private bool hasSetupErrors = false;

	private void Start()
	{
		if(playerActiveMtl == null || playerDeactiveMtl == null)
		{
			hasSetupErrors = true;
			Debug.LogError("Materials are not set properly in "+name, transform);
		}

		myRenderer = GetComponent<Renderer>();
		if(myRenderer == null)
		{
			hasSetupErrors = true;
			Debug.LogError("Renderer is not set for this Floor Gems Object : "+name, transform);
		}
	}

	private void Update()
	{
		if (hasSetupErrors)
		{
			return;
		}

		Vector3 ballVelocity = MoveBallSingleton.instance.GetBallVelocity();

		if (detectionAxis == DirectionEnums.POSITIVE_X_AXIS)
		{
			if (ballVelocity.x > 0)
			{
				myRenderer.material = playerActiveMtl;
			}
			else
			{
				myRenderer.material = playerDeactiveMtl;
			}
		}
		else if (detectionAxis == DirectionEnums.NEGATIVE_X_AXIS)
		{
			if (ballVelocity.x < 0)
			{
				myRenderer.material = playerActiveMtl;
			}
			else
			{
				myRenderer.material = playerDeactiveMtl;
			}
		}
		else if (detectionAxis == DirectionEnums.POSITIVE_Z_AXIS)
		{
			if (ballVelocity.z > 0)
			{
				myRenderer.material = playerActiveMtl;
			}
			else
			{
				myRenderer.material = playerDeactiveMtl;
			}
		}
		else if (detectionAxis == DirectionEnums.NEGATIVE_Z_AXIS)
		{
			if (ballVelocity.z < 0)
			{
				myRenderer.material = playerActiveMtl;
			}
			else
			{
				myRenderer.material = playerDeactiveMtl;
			}
		}

	}
}