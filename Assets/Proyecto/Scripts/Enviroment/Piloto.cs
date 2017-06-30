using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piloto : ItemReceiver {
    public override void Interact( PlayerInteractor interactor ) {
        if ( (data as PilotoDescriptor).canActivate() ) {
            return;
        }
        base.Interact( interactor );
    }
}
