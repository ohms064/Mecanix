using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReceiver : InteractiveBehaviour {

    [SerializeField]ReceiverDescriptor data;

    public override void Interact( PlayerInteractor interactor ) {
        if ( interactor.grabbedObjectData == null ) {
            return;
        }
        if ( interactor.grabbedObjectData.data.Equals( data.itemInteractions.item )) {
            interactor.grabbedObjectData.Interact( this );
            Transform droppedObject = interactor.Drop();
            droppedObject.gameObject.SetActive( false );
            data.isActive = true;
            Debug.Log( data.itemInteractions.correctText );
        }
        else {
            Debug.Log( data.failedInteraction );
        }

    }

    public override void Interact( InteractiveBehaviour interactor ) {
        
    }

    public override void Restart() {
    }
}
