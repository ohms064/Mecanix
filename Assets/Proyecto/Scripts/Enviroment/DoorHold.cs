using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHold : Door {
    private float t = 0;

    public override void Interact( PlayerInteractor interactor ) {
    }

    public override void Interact( InteractiveBehaviour interactor ) {
        if ( interactor.message ){
            if ( !data.isActive ) {
                data.isActive = true;
                if ( !isOpen ) {
                    StopCoroutine( "Close" );
                }
                StartCoroutine( "Open" );
            }
        }
        else{
            if ( data.isActive ) {
                data.isActive = false;
                if ( isOpen ) {
                    StopCoroutine( "Open" );
                }
                StartCoroutine( "Close" );
            }
        }
    }

    protected override IEnumerator Open() {
        float beginTime = Time.timeSinceLevelLoad;
        isOpen = true;
        while ( t < 1 ) {
            t = (Time.timeSinceLevelLoad - beginTime) / animationDuration;
            transform.position = Vector3.Lerp( origin, destiny, t );
            yield return new WaitForEndOfFrame();
        }
    }

    protected override IEnumerator Close() {
        float beginTime = Time.timeSinceLevelLoad;
        isOpen = false;
        while ( t < 1 ) {
            t = (Time.timeSinceLevelLoad - beginTime) / animationDuration;
            transform.position = Vector3.Lerp( destiny, origin, t );
            yield return new WaitForEndOfFrame();
        }       
    }
}
