using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBillboard : MonoBehaviour {

    Canvas canvas;

	// Use this for initialization
	void Start () {
        canvas = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt( GameManager.instance.player.transform, Vector3.up );
        transform.forward = -transform.forward;
	}
}
