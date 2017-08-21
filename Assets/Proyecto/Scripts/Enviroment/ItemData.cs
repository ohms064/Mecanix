using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : InteractiveBehaviour {
    public ItemDescriptor data;
    public Collider col;

    public override void Start() {
        base.Start();
        col = GetComponent<Collider>();
    }

    public override void Interact( PlayerInteractor interactor ) {
        if ( interactor.secondInteraction ) {
            for ( int i = 0; i < events.Length; i++ ) {
                events[i].EndEvent();
            }
            col.enabled = true;
            interactor.Drop();
            
        }
        else {
            for ( int i = 0; i < events.Length; i++ ) {
                events[i].StartEvent();
            }
            interactor.Grab( this );
            col.enabled = false;
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
