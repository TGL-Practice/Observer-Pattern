/*
    File made by TGL(The Game Learner)
    Learning purpose
    v 1.0
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public float xForce = 10.0f;
    public float zForce = 10.0f;
    //public float yForce = 10.0f;
    Rigidbody myRigidbody;


    private Vector3 initialPos;
    private void Start()
    {
        initialPos = transform.position;
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
		{
            myRigidbody.velocity = Vector3.zero;
            myRigidbody.angularVelocity = Vector3.zero;
		}
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            myRigidbody.velocity = Vector3.zero;
            myRigidbody.angularVelocity = Vector3.zero;
            transform.position = initialPos;

        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
        {
            //this is for x axis' movement  
            float x = 0.0f;
            if (Input.GetKey(KeyCode.A))
            {
                x = x - xForce;
            }

            if (Input.GetKey(KeyCode.D))
            {
                x = x + xForce;
            }

            //this is for z axis' movement
            float z = 0.0f;
            if (Input.GetKey(KeyCode.S))
            {
                z = z - zForce;
            }

            if (Input.GetKey(KeyCode.W))
            {
                z = z + zForce;
            }

            //this is for z axis' movement
            //float y = 0.0f;
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    y = yForce;
            //}

            myRigidbody.AddForce(x, 0, z);
        }
    }
}