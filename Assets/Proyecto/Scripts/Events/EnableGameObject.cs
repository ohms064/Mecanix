using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameObject : EventBehaviour {
    public bool onActiveEnabled = false, onStartEventEnabled = false;
    public bool onDeactiveEnabled = false, onEndEventEnabled = false;
    public override void EndEvent() {
        gameObject.SetActive( onEndEventEnabled );
    }

    public override void OnActivate( Descriptor desc ) {
        gameObject.SetActive( onActiveEnabled );
    }

    public override void OnDeactivate( Descriptor desc ) {
        gameObject.SetActive( onDeactiveEnabled );
    }

    public override void OnStart() {
        
    }

    public override void StartEvent() {
        gameObject.SetActive( onStartEventEnabled );
    }
}
