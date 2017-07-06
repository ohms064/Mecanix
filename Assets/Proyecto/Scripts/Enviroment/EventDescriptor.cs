using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDescriptor : MonoBehaviour {

    public Descriptor descriptor;

	public virtual void StartEvent(){}
	public virtual void OnActivate(Descriptor desc) {}
    public virtual void OnStart() { }
    public virtual void OnDeactivate(Descriptor desc) { }

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
}