using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : InteractiveBehaviour {
    public InteractorDescriptor data;
    public InteractiveBehaviour[] effect;
    Material material;
    public Color activeColor;
    void Start(){
        material = GetComponent<Renderer>().material;
        data.Activate += OnActivate;
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

    public void OnActivate(Descriptor descriptor){
        material.color = activeColor;
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
}
