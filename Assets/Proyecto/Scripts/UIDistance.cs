using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDistance : MonoBehaviour {
    Canvas canvas;

    private void Start() {
        canvas = GetComponentInChildren<Canvas>();
        canvas.gameObject.SetActive( false );
    }

    private void OnTriggerEnter( Collider other ) {
        canvas.gameObject.SetActive( true );
    }

    private void OnTriggerExit( Collider other ) {
        canvas.gameObject.SetActive( false );
    }

}
