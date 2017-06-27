using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : InteractiveBehaviour {
    public InteractorDescriptor data;
    public InteractiveBehaviour[] effect;
    public override void Interact( PlayerInteractor interactor ) {
        if ( effect == null ) {
            return;
        }
        for ( int i = 0; i < data.requiredObjects.Length; i++ ) {
            if ( !data.requiredObjects[i].isActive ) {
                Debug.Log( data.failedText );
                return;
            }
        }
        Debug.Log( data.successText );
        for ( int i = 0; i < effect.Length; i++ ) {
            effect[i].Interact( this );
        }
    }

    public override void Interact( InteractiveBehaviour interactor ) {
    }

    public override void Restart() {
        throw new NotImplementedException();
    }
}
