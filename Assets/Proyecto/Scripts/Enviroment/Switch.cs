using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : InteractiveBehaviour {
    [SerializeField] InteractiveBehaviour objectToInteract;

    public override void Interact( PlayerInteractor interactor ) {
        throw new NotImplementedException();
    }

    public override void Interact( InteractiveBehaviour interactor ) {
        throw new NotImplementedException();
    }

    public override void Restart() {
        throw new NotImplementedException();
    }

    private void OnCollisionEnter( Collision collision ) {
        objectToInteract.Interact( this );
    }

}
