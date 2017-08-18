using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionEvent : EventBehaviour {
    Material material;
    public bool onActiveEnabled = false, onStartEventEnabled = false;
    public bool onDeactiveEnabled = false, onEndEventEnabled = false;

    public override void EndEvent() {
        SetEmission( onEndEventEnabled );
    }

    public override void OnActivate( Descriptor desc ) {
        SetEmission( onActiveEnabled );
    }

    public override void OnDeactivate( Descriptor desc ) {
        SetEmission( onDeactiveEnabled );
    }

    public override void OnStart() {
        
    }

    public override void StartEvent() {
        SetEmission( onStartEventEnabled );
    }

    // Use this for initialization
    void Start () {
        material = GetComponent<Renderer>().material;
	}

    private void SetEmission( bool val ) {
        if ( val ) {
            material.EnableKeyword( "_EMISSION" );
        }
        else {
            material.DisableKeyword( "_EMISSION" );
        }
        
    }

}
