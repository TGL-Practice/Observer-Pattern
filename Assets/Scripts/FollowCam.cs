/*
    File made by TGL(The Game Learner)
    Learning purpose
    v 1.0
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform player; // ball

    private Vector3 _offset; // distance from the ball from first frame
    private Rigidbody playerRigidBody;
    private bool playerHasRigidbody;
    //private Quaternion originalRot;

    void Start()
    {
        // originalRot = transform.rotation;
        if (player != null)
        {
            _offset = transform.position - player.position;
            playerRigidBody = player.GetComponent<Rigidbody>();
            if (playerRigidBody)
            {
                playerHasRigidbody = true;
            }
        }
        else
		{
            Debug.LogError("Player not found, so script cannot run");
		}
    }

    void Update()
    {
        if (playerHasRigidbody)
        {
            transform.position = player.transform.position + (_offset);
            //transform.LookAt(player.transform);
            //transform.rotation = originalRot;
        }
    }
}