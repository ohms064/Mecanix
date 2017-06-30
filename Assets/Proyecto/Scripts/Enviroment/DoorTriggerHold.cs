using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerHold : DoorTrigger {
    private void OnTriggerEnter( Collider other ) {
        isInside = true;
        message = true;
        door.Interact( this );
    }

    private void OnTriggerExit( Collider other ) {
        isInside = false;
        message = false;
        door.Interact( this );
    }
}
