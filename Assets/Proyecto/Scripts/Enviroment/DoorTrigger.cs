using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : InteractiveBehaviour {
    [HideInInspector]public bool isInside;
    public Door door;

    public override void Interact( PlayerInteractor interactor ) {
        
    }

    public override void Interact( InteractiveBehaviour interactor ) {
        
    }

    public override void Restart() {
        
    }

    private void OnTriggerEnter( Collider other ) {
        isInside = true;
        door.Interact(this);
    }

    private void OnTriggerExit( Collider other ) {
        isInside = false;
    }
}
