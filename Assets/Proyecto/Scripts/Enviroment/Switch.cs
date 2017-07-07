using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : InteractiveBehaviour {
    [SerializeField] InteractorDescriptor data;
    [SerializeField] InteractiveBehaviour[] objectsToInteract;

    public override void Interact( PlayerInteractor interactor ) {
        
    }

    public override void Interact( InteractiveBehaviour interactor ) {
        
    }

    public override void Restart() {

    }

    private void OnCollisionEnter( Collision collision ) {
        if ( collision.gameObject.GetComponent<WeightedItemData>() == null ) {
            return;
        }
        message = true;
        for ( int i = 0; i < objectsToInteract.Length; i++ ) {
            objectsToInteract[i].Interact( this );
        }
        
    }

    private void OnCollisionExit( Collision collision ) {
        if ( collision.gameObject.GetComponent<WeightedItemData>() == null ) {
            return;
        }
        message = false;
        for ( int i = 0; i < objectsToInteract.Length; i++ ) {
            objectsToInteract[i].Interact( this );
        }
    }

}
