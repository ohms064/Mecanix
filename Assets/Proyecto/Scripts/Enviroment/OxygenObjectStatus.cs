using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenObjectStatus : InteractiveBehaviour {
    private OxygenManager manager;
    private Material material;
    public Color normal, warning, danger;

    public override void Interact( PlayerInteractor interactor ) {
        Debug.Log( manager.descriptor.description );
    }

    public override void Interact( InteractiveBehaviour interactor ) {
        OxygenManager.instance.Fix();
    }

    public void OnOxygenWarning() {
        material.color = warning;
    }

    public void OnOxygenDanger() {
        material.color = danger;
    }

    public void OnOxygenNormal() {
        material.color = normal;
    }

    private void OnEnable() {
        manager = OxygenManager.instance;
        material = GetComponent<Renderer>().material;
        manager.descriptor.OxygenDanger += OnOxygenDanger;
        manager.descriptor.OxygenOk += OnOxygenNormal;
        manager.descriptor.OxygenWarning += OnOxygenWarning;
        
    }

    private void OnDisable() {
        manager.descriptor.OxygenDanger -= OnOxygenDanger;
        manager.descriptor.OxygenOk -= OnOxygenNormal;
        manager.descriptor.OxygenWarning -= OnOxygenWarning;
    }

    public override void Restart() {
        
    }
}
