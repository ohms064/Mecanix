﻿using UnityEngine;
using System.Collections;

[RequireComponent( typeof( CharacterController ) )]
public class EditorMovementController : MonoBehaviour {
    public float speedMovement = 1.0f, speedRotation = 1.0f;

    private CharacterController ch;
    private Vector3 vectorMovement;
    [SerializeField] private Transform childCamera;
    private float angleX, jump;
    private bool isFalling;

    // Use this for initialization
    void Start() {
        ch = this.GetComponent<CharacterController>();
        jump = 0.0f;
        isFalling = false;
    }

    // Update is called once per frame
    void Update() {
        vectorMovement = Vector3.zero;
        /*
        if ( !ch.isGrounded ) {
            vectorMovement.y -= 0.1f;
        }
        else {
            isFalling = false;
            jump = 0.0f;
        }
        if ( !isFalling && Input.GetKey( KeyCode.Space ) && jump < 5.0f ) {
            vectorMovement.y += 0.2f;
            jump += 0.2f;
        }
        else {
            if ( jump >= 0.2f ) {
                isFalling = true;
                jump -= 0.2f;
            }
        }
        */
        vectorMovement += (
            (childCamera.right * Input.GetAxis( "Horizontal" ) * Time.deltaTime * speedMovement)
            + (childCamera.forward * Input.GetAxis( "Vertical" ) * Time.deltaTime * speedMovement)
            ) * (Input.GetKey( KeyCode.LeftShift ) ? 1.5f : 1.0f);

        ch.Move( vectorMovement );

        transform.Rotate( Vector3.up, Input.GetAxis( "Mouse X" ) * Time.deltaTime * speedRotation, Space.World );

        childCamera.Rotate( Vector3.right, -Input.GetAxis( "Mouse Y" ) * Time.deltaTime * speedRotation );

        angleX = childCamera.localEulerAngles.x;
        angleX = (angleX > 180.0f) ? angleX - 360 : angleX;
        angleX = Mathf.Clamp( angleX, -45.0f, 45.0f );
        childCamera.localEulerAngles = new Vector3( angleX, childCamera.localEulerAngles.y, childCamera.localEulerAngles.z );

    }

}