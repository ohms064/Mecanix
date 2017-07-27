using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFix : MonoBehaviour {
    Vector3 initialPosition;
    public float maxDistance;

	// Use this for initialization
	void Start () {
        initialPosition = transform.position;
        maxDistance = maxDistance * maxDistance;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if ( (transform.position - initialPosition).sqrMagnitude >= maxDistance ) {
            transform.position = initialPosition;
        }
	}
}
