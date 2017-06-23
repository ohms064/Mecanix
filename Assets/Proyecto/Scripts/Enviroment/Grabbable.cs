using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemData))]
public class Grabbable : InteractiveBehaviour {

    public override void Interact( PlayerInteractor interactor ) {
        interactor.Grab( this.transform );
    }

    public override void Interact( InteractiveBehaviour interactor ) {
        throw new NotImplementedException();
    }
}
