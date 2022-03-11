/*
    File made by TGL(The Game Learner)
    Learning purpose
    v 1.0
*/

using System;
using UnityEngine;

namespace TGLUtility.ObserverPattern
{
	public interface IObservedObj
	{
		/// <summary>
		/// interface Action for ObsPtrnStateDemo
		/// </summary>
		public event Action<ObsPtrnStateDemo> stateOfHandlerChanged;
		/// <summary>
		/// interface implementation of UpdateStateDir method
		/// </summary>
		/// <param name="currDir">Current Direction of movement</param>
		public void UpdateStateDir(Vector3 currDir);
		/// <summary>
		/// interface implementation of UpdateStatePos method
		/// </summary>
		/// <param name="currPos">Current Position of Subject</param>
		public void UpdateStatePos(Vector3 currPos);

		/// <summary>
		/// interface implementation of UpdateDirAndPos method
		/// </summary>
		/// <param name="currDir">Current Direction of movement</param>
		/// <param name="currPos">Current Position of Subject</param>
		public void UpdateDirAndPos(Vector3 currDir, Vector3 currPos);
	}
}