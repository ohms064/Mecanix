using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerHold : DoorTrigger {
    private void OnTriggerEnter( Collider other ) {
        isInside = true;
        message = true;
        for(int i = 0; i < door.Length; i++) {
            door[i].Interact(this);
        }
    }

    private void OnTriggerExit( Collider other ) {
        isInside = false;
        message = false;
        for (int i = 0; i < door.Length; i++) {
            door[i].Interact(this);
        }
    }
}
