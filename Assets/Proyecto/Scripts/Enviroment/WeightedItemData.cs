using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedItemData : ItemData {

    Rigidbody rb;

    public override void Start() {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }

    public override void Interact( PlayerInteractor interactor ) {
        base.Interact( interactor );
        if ( interactor.secondInteraction ) {
            rb.useGravity = true;
            //rb.isKinematic = false;
        }
        else {
            rb.useGravity = false;
            //rb.isKinematic = true;
            
        }
    }


    private void OnCollisionEnter( Collision collision ) {
        if ( rb.useGravity || collision.gameObject.layer == LayerMask.NameToLayer("Player") ){
            return;
        }
        PlayerInteractor player = GameManager.instance.player.GetComponent<PlayerInteractor>();
        rb.useGravity = true;
        player.Drop();
    }
}
