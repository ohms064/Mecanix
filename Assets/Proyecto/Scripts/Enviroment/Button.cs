using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : InteractiveBehaviour {
    public InteractorDescriptor data;
    public InteractiveBehaviour[] effect;
    Material material;
    public override void Start(){
        base.Start();
        material = GetComponent<Renderer>().material;        
    }

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
        if(data.IsActive){
            DebugUI.instance.Log( data.successText );
            return;
        }
        if ( !data.canActivate() ) {
            DebugUI.instance.Log( data.failedText );
            return;
        }
        data.IsActive = true;
        DebugUI.instance.Log( data.successText );
        for ( int i = 0; i < effect.Length; i++ ) {
            effect[i].Interact( this );
        }
    }

    private void OnEnable() {
        for ( int i = 0; i < events.Length; i++ ) {
            data.Activate += events[i].OnActivate;
            data.Deactivate += events[i].OnDeactivate;
        }
    }

    private void OnDisable() {
        for ( int i = 0; i < events.Length; i++ ) {
            data.Activate -= events[i].OnActivate;
            data.Deactivate -= events[i].OnDeactivate;
        }
    }
}
