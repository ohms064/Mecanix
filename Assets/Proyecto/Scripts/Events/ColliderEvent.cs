using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEvent : EventBehaviour {
    public bool onGrabEnabled = false;
    public bool onDropEnabled = false;
    private Collider col;

    void Start() {
        col = GetComponent<Collider>();
    }

    public override void EndEvent() {
        col.enabled = onDropEnabled;
    }

    public override void OnActivate( Descriptor desc ) {
    }

    public override void OnDeactivate( Descriptor desc ) {
    }

    public override void OnStart() {
    }

    public override void StartEvent() {
        col.enabled = onGrabEnabled;
    }
}