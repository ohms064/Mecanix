using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHold : Door {
    private float t = 0;
    private float animInverse;

    private new void Start() {
        origin = this.transform.position;
        animInverse = animationDuration;
        destiny += origin;
    }

    public override void Interact( PlayerInteractor interactor ) {
    }

    public override void Interact( InteractiveBehaviour interactor ) {
        if ( interactor.message ){

                if ( !isOpen ) {
                    StopCoroutine( Close() );
                }
                StartCoroutine( Open() );
            
        }
        else{

                if ( isOpen ) {
                    StopCoroutine( Open() );
                }
                StartCoroutine( Close() );
            }
        
    }

    protected override IEnumerator Open() {
        float beginTime = Time.timeSinceLevelLoad;
        isOpen = true;
        for ( int i = 0; i < events.Length; i++ ) {
            events[i].StartEvent();
        }
        while ( t < 1 ) {
            t += Time.deltaTime * animInverse;
            transform.position = Vector3.Lerp( origin, destiny, t );
            yield return new WaitForEndOfFrame();
        }
    }

    protected override IEnumerator Close() {
        float beginTime = Time.timeSinceLevelLoad;
        isOpen = false;
        for ( int i = 0; i < events.Length; i++ ) {
            events[i].EndEvent();
        }
        while ( t > 0 ) {
            t -= Time.deltaTime * animInverse;
            transform.position = Vector3.Lerp( origin, destiny, t );
            yield return new WaitForEndOfFrame();
        }       
    }
}
