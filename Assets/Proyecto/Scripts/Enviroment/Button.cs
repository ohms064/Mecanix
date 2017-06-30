﻿using System;
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
            return;
        }
        Debug.Log( data.successText );
        for ( int i = 0; i < effect.Length; i++ ) {
            effect[i].Interact( this );
        }
    }
}
