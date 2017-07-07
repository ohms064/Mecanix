using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piloto : ItemReceiver {
    
    public override void Interact( PlayerInteractor interactor ) {
        PilotoDescriptor pilot = (data as PilotoDescriptor);
        if(pilot == null) {
            return;
        }
        if ( pilot.canActivate() ) {
            DebugUI.instance.Log(pilot.successText);
            return;
        }
        base.Interact( interactor );
    }
}
