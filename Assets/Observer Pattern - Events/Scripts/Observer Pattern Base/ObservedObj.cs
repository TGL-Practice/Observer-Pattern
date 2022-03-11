/*
    File made by TGL(The Game Learner)
    Learning purpose
    v 1.0
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TGLUtility.ObserverPattern
{
	/// <summary>
	/// Subject in an observer pattern
	/// </summary>
	public class ObservedObj : MonoBehaviour, IObservedObj
	{
		private readonly ObsPtrnStateDemo stateInstance;

		public event Action<ObsPtrnStateDemo> stateOfHandlerChanged;

		private Rigidbody _rigidbody;
		private Vector3 prevPos;
		private float distVal, velVal;

		private void Awake()
		{
			prevPos = transform.position;
			if (_rigidbody == null)
			{
				_rigidbody = transform.GetComponent<Rigidbody>();
				if(_rigidbody)
				{
					Debug.Log("ObservedObj - Subject is set up for observation");
				}
				else
				{
					Debug.LogError("ObservedObj - Subject did not find a rigidbody needed for the logic so destroying this obj", transform);
					Destroy(this);
				}
			}
		}

		public ObservedObj()
		{
			stateInstance = new ObsPtrnStateDemo(Vector3.zero, Vector3.zero);
		}

		public ObservedObj(Vector3 currPos, Vector3 currDir)
		{
			stateInstance = new ObsPtrnStateDemo(currPos, currDir);
		}

		public void UpdateStateDir(Vector3 currDir)
		{
			stateInstance.currentGlobalDirection = currDir;
			if (stateOfHandlerChanged != null)
			{
				stateOfHandlerChanged(stateInstance);
			}
		}

		public void UpdateStatePos(Vector3 currPos)
		{
			stateInstance.currentGlobalPosition = currPos;
			if (stateOfHandlerChanged != null)
			{
				stateOfHandlerChanged(stateInstance);
			}
		}

		public void UpdateDirAndPos(Vector3 currDir, Vector3 currPos)
		{
			stateInstance.currentGlobalDirection = currDir;
			stateInstance.currentGlobalPosition = currPos;
			if (stateOfHandlerChanged != null)
			{
				stateOfHandlerChanged(stateInstance);
			}
		}

		private void Update()
		{
			distVal = Vector3.Distance(prevPos, transform.position);
			if (_rigidbody)
			{
				velVal = _rigidbody.velocity.magnitude;
			}
			else
			{
				velVal = 0.0f;
			}

			if(velVal > 0.01f && distVal > 0.1f)
			{
				UpdateDirAndPos(_rigidbody.velocity.normalized, transform.position);
			}
			else if (velVal > 0.01f)
			{
				UpdateStateDir(_rigidbody.velocity.normalized);
			}
			else if (distVal > 0.1f)
			{
				prevPos = transform.position;
				UpdateStatePos(transform.position);
			}
		}
	}
}