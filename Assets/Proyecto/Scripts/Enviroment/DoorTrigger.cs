using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : InteractiveBehaviour {
    [HideInInspector]public bool isInside;
    public Door[] door;

    public override void Interact( PlayerInteractor interactor ) {
        
    }

    public override void Interact( InteractiveBehaviour interactor ) {
        if ( isInside ) {
            TryOpen();
        }
    }

    public override void Restart() {
        
    }

    private void OnTriggerEnter( Collider other ) {
        isInside = true;
        TryOpen();
        
    }

    private void TryOpen() {
        for ( int i = 0; i < door.Length; i++ ) {
            if ( door[i].isOpen ) {
                return;
            }
        }
        for ( int i = 0; i < door.Length; i++ ) {
            door[i].Interact( this );
        }
    }

    private void OnTriggerExit( Collider other ) {
        isInside = false;
    }
}
