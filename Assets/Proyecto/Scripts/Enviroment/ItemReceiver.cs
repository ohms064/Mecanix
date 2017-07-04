using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReceiver : InteractiveBehaviour {

    [SerializeField] protected ReceiverDescriptor data;
    [SerializeField] protected InteractiveBehaviour[] effect;

    public override void Interact( PlayerInteractor interactor ) {
        if ( interactor.grabbedObjectData == null ) {
            DebugUI.instance.Log( data.IsActive ? data.activeDescription : data.description );
            return;
        }
        if ( interactor.grabbedObjectData.data.Equals( data.itemInteractions.item )) {
            interactor.grabbedObjectData.Interact( this );
            Transform droppedObject = interactor.Drop();
            droppedObject.gameObject.SetActive( false );
            data.IsActive = true;
            DebugUI.instance.Log( data.itemInteractions.correctText );
            for ( int i = 0; i < effect.Length; i++ ) {
                effect[i].Interact( this );
            }
        }
        else if(!data.IsActive){
            DebugUI.instance.Log( data.failedInteraction );
        }

    }

    public override void Interact( InteractiveBehaviour interactor ) {
        
    }

    public override void Restart() {
    }
}
