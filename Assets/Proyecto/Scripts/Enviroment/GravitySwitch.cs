using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : InteractiveBehaviour {
    [SerializeField] GravityDescriptor descriptor;
    private bool on = false;

    private void Awake() {
        Physics.gravity = descriptor.gravityValue;
    }

    
    public override void Start(){
        base.Start();
        descriptor.ActivateGravity += OnActivate;
        descriptor.DeactivateGravity += OnDeactivate;
    }


    public override void Interact( PlayerInteractor interactor ) {
        if (on) {
            return;
        }
        DebugUI.instance.Log( descriptor.activeDescription );
        descriptor.Set( on, this );
    }

    public override void Interact( InteractiveBehaviour interactor ) {
        
    }

    public override void Restart() {
        
    }

    public void OnActivate(Descriptor descriptor){
        on = false;
        for ( int i = 0; i < events.Length; i++ ) {
            events[i].OnActivate( descriptor );
        }
    }

    public void OnDeactivate(Descriptor descriptor){
        for ( int i = 0; i < events.Length; i++ ) {
            events[i].OnDeactivate( descriptor );
        }
    }
}
