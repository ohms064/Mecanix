using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : InteractiveBehaviour {
    public ItemDescriptor data;

    public override void Interact( PlayerInteractor interactor ) {
        interactor.Grab( this.transform );
    }

    public override void Interact( InteractiveBehaviour interactor ) {
        if ( interactor is ItemReceiver ) {
            data.isActive = true;
        }
        
    }

    private void Awake() {
        if ( data.isActive ) {
            gameObject.SetActive( false );
        }
    }

    private void Start() {
        if ( data.position != Vector3.zero ) {
            transform.position = data.position;
        }
    }

    private void OnDestroy() {
        data.position = transform.position;
    }

    public override void Restart() {
        
    }
}
