using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : InteractiveBehaviour {
    [SerializeField] GravityDescriptor descriptor;
    private bool on = true;
    Material material;
    public Color activeColor;
    Color inactiveColor;

    private void Awake() {
        Physics.gravity = descriptor.gravityValue;
    }

    
    void Start(){
        material = GetComponent<Renderer>().material;
        descriptor.ActivateGravity += OnActivate;
        inactiveColor = material.color;
        descriptor.DeactivateGravity += OnDeactivate;
    }


    public override void Interact( PlayerInteractor interactor ) {
        on = !on;
        descriptor.Set( on, this );
    }

    public override void Interact( InteractiveBehaviour interactor ) {
        
    }

    public override void Restart() {
        
    }

    public void OnActivate(Descriptor descriptor){
        material.color = activeColor;
    }

    public void OnDeactivate(Descriptor descriptor){
        material.color = inactiveColor;
    }
}
