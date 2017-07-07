using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventBehaviour : MonoBehaviour {

    //public Descriptor descriptor;

    public abstract void OnActivate( Descriptor desc );
    public abstract void OnStart();
    public abstract void StartEvent();
    public abstract void EndEvent();
    public abstract void OnDeactivate( Descriptor desc );
    /*
    public void OnEnable() {
        if (descriptor == null) return;
        descriptor.Activate += OnActivate;
        descriptor.Deactivate += OnDeactivate;
    }

    public void OnDisable() {
        if (descriptor == null) return;
        descriptor.Activate -= OnActivate;
        descriptor.Deactivate -= OnDeactivate;
    }
    */
}