/*
    File made by TGL(The Game Learner)
    Learning purpose
    v 1.0
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightQuadrentSingleton : MonoBehaviour
{
    public Material activeQuadMtl;
    public Material deactiveQuadMtl;
    [Space(10)]
    [Tooltip("1st Quad")]
    public Transform Quad_xPos_zPos; // 1st
    [Tooltip("2nd Quad")] 
    public Transform Quad_xNeg_zPos; // 2nd
    [Tooltip("3rd Quad")] 
    public Transform Quad_xNeg_zNeg; // 3rd
    [Tooltip("4th Quad")] 
    public Transform Quad_xPos_zNeg; // 4th


    private Renderer quad_xPos_zPos; // 1st
    private Renderer quad_xNeg_zPos; // 2nd
    private Renderer quad_xNeg_zNeg; // 3rd
    private Renderer quad_xPos_zNeg; // 4th

    private Vector3 ballPos;
    private bool hasSetupError;
    private void Start()
	{
        quad_xPos_zPos = Quad_xPos_zPos.GetComponent<Renderer>();
        quad_xNeg_zPos = Quad_xNeg_zPos.GetComponent<Renderer>();
        quad_xNeg_zNeg = Quad_xNeg_zNeg.GetComponent<Renderer>();
        quad_xPos_zNeg = Quad_xPos_zNeg.GetComponent<Renderer>();

        if(quad_xPos_zPos == null || quad_xNeg_zPos == null || quad_xNeg_zNeg == null || quad_xPos_zNeg == null)
		{
            Debug.LogError("renderer not found for a quadrent");
            hasSetupError = true;

        }
    }

	private void Update()
	{
        if(hasSetupError)
		{
            return;
		}

        ballPos = MoveBallSingleton.instance.GetBallPosition();

        //quad1
        if (ballPos.x >= 0 && ballPos.z >= 0) 
		{
            quad_xPos_zPos.material = activeQuadMtl;
        }
        else
		{
            if(quad_xPos_zPos.sharedMaterial == activeQuadMtl)
			{
                quad_xPos_zPos.material = deactiveQuadMtl;
            }
        }

        //quad 2
        if (ballPos.x < 0 && ballPos.z >= 0)
        {
            quad_xNeg_zPos.material = activeQuadMtl;
        }
        else
        {
            if (quad_xNeg_zPos.sharedMaterial == activeQuadMtl)
            {
                quad_xNeg_zPos.material = deactiveQuadMtl;
            }
        }

        //quad 3
        if (ballPos.x < 0 && ballPos.z < 0)
        {
            quad_xNeg_zNeg.material = activeQuadMtl;
        }
        else
        {
            if (quad_xNeg_zNeg.sharedMaterial == activeQuadMtl)
            {
                quad_xNeg_zNeg.material = deactiveQuadMtl;
            }
        }

        //quad 4
        if (ballPos.x >= 0 && ballPos.z < 0)
        {
            quad_xPos_zNeg.material = activeQuadMtl;
        }
        else
        {
            if (quad_xPos_zNeg.sharedMaterial == activeQuadMtl)
            {
                quad_xPos_zNeg.material = deactiveQuadMtl;
            }
        }
    }
}