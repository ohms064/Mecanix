using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialEvent : EventBehaviour {
    protected Material material;
    [SerializeField] Color active;
	// Use this for initialization
	void Start () {
        material = GetComponent<Renderer>().material;
	}

    public override void OnActivate( Descriptor desc ) {
        material.color = active;
    }

    public override void OnStart() {
        
    }

    public override void OnDeactivate( Descriptor desc ) {
        
    }

    public override void StartEvent() {
    }

    public override void EndEvent() {
    }
}
