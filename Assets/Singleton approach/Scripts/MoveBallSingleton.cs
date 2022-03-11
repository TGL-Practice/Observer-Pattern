/*
    File made by TGL(The Game Learner)
    Learning purpose
    v 1.0
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBallSingleton : MonoBehaviour
{
    private static MoveBallSingleton _instance;

    public static MoveBallSingleton instance { get { return _instance; } }

    private Rigidbody myRigidBody;

    private void Awake()
	{
        if(_instance != null)
		{
            Destroy(gameObject);
            return;
		}
        _instance = this;
        myRigidBody = GetComponent<Rigidbody>();

    }

    public Vector3 GetBallVelocity()
	{
        return myRigidBody.velocity;
	}

    public Vector3 GetBallPosition()
    {
        return transform.position;
    }
}