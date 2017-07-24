using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : InteractiveBehaviour {
    public ItemDescriptor data;

    public override void Interact( PlayerInteractor interactor ) {
        if ( interactor.secondInteraction ) {
            for ( int i = 0; i < events.Length; i++ ) {
                events[i].EndEvent();
            }
            interactor.Drop();
        }
        else {
            for ( int i = 0; i < events.Length; i++ ) {
                events[i].StartEvent();
            }
            interactor.Grab( this );
            if(DebugUI.instance != null)
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
