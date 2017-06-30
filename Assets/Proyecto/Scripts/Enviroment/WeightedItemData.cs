using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedItemData : ItemData {

    Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public void OnCollisionEnter( Collision collision ) {
        var b = collision.gameObject.GetComponent<InteractiveBehaviour>();
        if ( b != null ) {
            message = true;
            b.Interact( this );
        }
    }

    public void OnCollisionExit( Collision collision ) {
        var b = collision.gameObject.GetComponent<InteractiveBehaviour>();
        if ( b != null ) {
            message = false;
            b.Interact( this );
        }
    }
    public override void Interact( PlayerInteractor interactor ) {
        base.Interact( interactor );
        if ( interactor.secondInteraction ) {
            rb.useGravity = true;
            rb.isKinematic = false;
        }
        else {
            rb.useGravity = false;
            rb.isKinematic = true;
        }
    }
}
