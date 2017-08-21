using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInteraction : InteractiveBehaviour {
    public override void Interact( PlayerInteractor interactor ) {
        for ( int i = 0; i < events.Length; i++ ) {
            events[i].StartEvent();
        }
    }

    public override void Interact( InteractiveBehaviour interactor ) {
    }

    public override void Restart() {
    }
}
