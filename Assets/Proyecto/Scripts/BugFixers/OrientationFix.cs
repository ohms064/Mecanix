using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationFix : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if ( !transform.up.Equals(Vector3.up) ){
            transform.up = Vector3.up;
        }
	}
}
