using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {
    public bool isInside;

    private void OnTriggerEnter( Collider other ) {
        isInside = true;
    }

    private void OnTriggerExit( Collider other ) {
        isInside = false;
    }
}
