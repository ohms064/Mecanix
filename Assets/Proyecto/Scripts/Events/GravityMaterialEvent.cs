using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMaterialEvent : MaterialEvent {
    [SerializeField] Color inactive;

    void Start() {
        material = GetComponent<Renderer>().material;
        material.color = inactive;
    }

    public override void OnDeactivate( Descriptor desc ) {
        material.color = inactive;
    }

    public override void OnStart() {
        
    }
}
