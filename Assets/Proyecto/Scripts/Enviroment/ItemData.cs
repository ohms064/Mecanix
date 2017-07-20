using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : InteractiveBehaviour {
    public ItemDescriptor data;

    public override void Interact( PlayerInteractor interactor ) {
        if ( interactor.secondInteraction ) {
            interactor.Drop();
        }
        else {
            interactor.Grab( this );
            DebugUI.instance.Log( data.description );
        }
    }

    public override void Interact( InteractiveBehaviour interactor ) {
        if ( interactor is ItemReceiver ) {
            data.IsActive = true;
        }
        
    }

    private void Awake() {
        if ( data.IsActive ) {
            gameObject.SetActive( false );
        }
    }

    public override void Restart() {
        
    }
}
