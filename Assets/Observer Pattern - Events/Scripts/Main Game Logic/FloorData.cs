/*
    File made by TGL(The Game Learner)
    Learning purpose
    v 1.0
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorData : MonoBehaviour
{
    public Renderer quad1, quad2, quad3, quad4;
    private List<Renderer> myrenderers;

	private void Awake()
	{
        myrenderers = new List<Renderer>();
        myrenderers.Add(quad1);
        myrenderers.Add(quad2);
        myrenderers.Add(quad3);
        myrenderers.Add(quad4);
    }

	public Renderer GetQuadRenderer(Vector3 relPos)
	{
        Renderer rendererOfspecificQuad = null;

        if (relPos.x < 0 && relPos.z < 0)
        {
            rendererOfspecificQuad = quad3;
        }
        else if (relPos.x < 0 && relPos.z >= 0)
        {
            rendererOfspecificQuad = quad2;
        }
        else if (relPos.x >= 0 && relPos.z >= 0)
        {
            rendererOfspecificQuad = quad1;
        }
        else if (relPos.x >= 0 && relPos.z < 0)
        {
            rendererOfspecificQuad = quad4;
        }            

        return rendererOfspecificQuad;
    }

    public void SetActiveQuadWithMtl(Vector3 relPos, Material activeMtl, Material deactiveMtl)
    {
        Renderer activeRender = GetQuadRenderer(relPos);

        foreach(Renderer rr in myrenderers)
		{
            if(rr == activeRender)
			{
                if (rr.sharedMaterial != activeMtl)
                {
                    rr.material = activeMtl;
                }
            }
            else
			{
                if (rr.sharedMaterial != deactiveMtl)
                {
                    rr.material = deactiveMtl;
                }
            }
		}
    }
}