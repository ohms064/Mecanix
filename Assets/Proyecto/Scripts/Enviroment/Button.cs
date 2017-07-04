using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : InteractiveBehaviour {
    public InteractorDescriptor data;
    public InteractiveBehaviour[] effect;
    public override void Interact( PlayerInteractor interactor ) {
        Activate();
    }

    public override void Interact( InteractiveBehaviour interactor ) {
        message = interactor.message;
        Activate();
    }

    public override void Restart() {
        
    }

    private void Activate() {
        if ( effect == null ) {
            return;
        }
        if ( !data.canActivate() ) {
            DebugUI.instance.Log( data.failedText );
            return;
        }
       
        for ( int i = 0; i < effect.Length; i++ ) {
            DebugUI.instance.Log( data.successText );
            effect[i].Interact( this );
        }
    }
}
