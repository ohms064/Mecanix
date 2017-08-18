using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piloto : ItemReceiver {
    
    public override void Interact( PlayerInteractor interactor ) {
        PilotoDescriptor pilot = (data as PilotoDescriptor);
        if(pilot == null) {
            return;
        }
        base.Interact( interactor );
        if ( pilot.canActivate() ) {
            DebugUI.instance.Log( pilot.successText );
            for ( int i = 0; i < events.Length; i++ ) {
                events[i].StartEvent();
            }
            return;
        }
    }
}
