using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : InteractiveBehaviour {
    [SerializeField] GravityDescriptor descriptor;
    private bool on = true;
    private void Awake() {
        Physics.gravity = descriptor.gravityValue;
    }
    public override void Interact( PlayerInteractor interactor ) {
        on = !on;
        descriptor.Set( on, this );
    }

    public override void Interact( InteractiveBehaviour interactor ) {
        
    }

    public override void Restart() {
        
    }
}
