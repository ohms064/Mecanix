using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piloto : ItemReceiver {
    public AnalyticsManager analytics;
    
    public override void Interact( PlayerInteractor interactor ) {
        PilotoDescriptor pilot = (data as PilotoDescriptor);
        if(pilot == null) {
            return;
        }
        if ( pilot.canActivate() ) {
            DebugUI.instance.Log(pilot.successText);
            analytics.totalTime = Time.timeSinceLevelLoad;
            for ( int i = 0; i < events.Length; i++ ) {
                events[i].StartEvent();
            }
            return;
        }
        base.Interact( interactor );
    }
}
