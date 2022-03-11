/*
    File made by TGL(The Game Learner)
    Learning purpose
    v 1.0
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TGLUtility.ObserverPattern
{
    /// <summary>
    /// Demo Class to store states of the Subject that is also used for events
    /// </summary>
    public class ObsPtrnStateDemo 
    {
        public Vector3 currentGlobalPosition;
        public Vector3 currentGlobalDirection;
		public ObsPtrnStateDemo(Vector3 cgPos, Vector3 cgdir)
		{
            currentGlobalPosition = cgPos;
            currentGlobalDirection = cgdir;
        }
    }
}